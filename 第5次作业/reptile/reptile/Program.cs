using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
namespace UniversityPhoneNumberCrawler
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly List<string> phoneNumberResults = new List<string>();
        static readonly object lockObj = new object();
        static async Task Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding("gb2312");
            Console.Write("请输入关键字：");
            // string keyword = Console.ReadLine();
            string keyword = "武汉大学电话"; // 以武汉大学为例
            Console.WriteLine($"搜索关键字：{keyword}");
            var searchResults = await Search(keyword, 5); // 获取前x页的搜索结果
            Console.WriteLine($"搜索结果：共 {searchResults.Count} 个");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"  {result}");
            }
            Console.WriteLine("开始爬取电话号码...");
            var tasks = new List<Task>();
            foreach (var url in searchResults)
            {
                tasks.Add(CrawlUrl(url));
            }
            await Task.WhenAll(tasks);
            Console.WriteLine($"共爬取到 {phoneNumberResults.Count} 个电话号码：");
            foreach (var result in phoneNumberResults)
            {
                Console.WriteLine($"  {result}");
            }
        }
        static async Task<List<string>> Search(string keyword, int pageCount)
        {
            var searchUrls = new List<string>
            {
                // $"https://www.baidu.com/s?wd={keyword}",
                $"https://www.bing.com/search?q={HttpUtility.UrlEncode(keyword)}",
            };
            var results = new List<string>();
            foreach (var url in searchUrls)
            {
                for (int page = 1; page <= pageCount; page++)
                {
                    var searchUrl = $"{url}&page={page}"; // 修改搜索链接以指定页码
                    Console.WriteLine($"正在访问 {searchUrl}...");
                    try
                    {
                        var html = await httpClient.GetStringAsync(searchUrl);
                        Console.WriteLine($"访问 {searchUrl} 成功，共 {html.Length} 字节");
                        var regex = new Regex(@"<a href=""(?<url>https?://[\w\d./?=#&]+)""");
                        var matches = regex.Matches(html);
                        foreach (Match match in matches)
                        {
                            var result = match.Groups["url"].Value;
                            results.Add(result);
                        }
                        Console.WriteLine($"从 {searchUrl} 中找到 {matches.Count} 个 URL");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"访问 {searchUrl} 失败：{ex.Message}");
                    }
                }
            }
            return results;
        }

        static async Task CrawlUrl(string url)
        {
            try
            {
                Console.WriteLine($"正在访问 {url}...");
                var html = await httpClient.GetStringAsync(url);
                Console.WriteLine($"访问 {url} 成功，共 {html.Length} 字节");
                var regex = new Regex(@"\b\d{3,4}-?\d{8}\b");
                var matches = regex.Matches(html);
                Console.WriteLine($"从 {url} 中找到 {matches.Count} 个电话号码");

                int phoneNumberCount = 0;
                foreach (Match match in matches)
                {
                    if (phoneNumberCount >= 100) break;
                    var phoneNumber = match.Value;
                    lock (lockObj)
                    {
                        if (!phoneNumberResults.Contains(phoneNumber))
                        {
                            phoneNumberResults.Add($"{phoneNumber}\t{url}");
                        }
                    }
                    phoneNumberCount++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"访问 URL {url} 失败：{ex.Message}");
            }
        }
    }
}