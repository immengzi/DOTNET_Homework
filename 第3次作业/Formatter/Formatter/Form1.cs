using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formatter
{
    public partial class Form1 : Form
    {
        private int lineCount;
        private int wordCount;
        public string source { get; set; }

        public Form1()
        {
            InitializeComponent();
            label2.Text = lineCount.ToString();
            label3.Text = wordCount.ToString();
        }
        
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "C#源文件|*.cs|所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                StreamReader sr = new StreamReader(filePath, Encoding.Default);
                source = sr.ReadToEnd();
                sr.Close();
                richTextBox1.Text = source;
                counts_Update(source);
                label2.Text = lineCount.ToString();
                label3.Text = wordCount.ToString();
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者：XMengH\nGitHub：https://github.com/immengzi", "关于");
        }

        private void 格式化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = source.Split('\n');
            List<string> newLines = new List<string>();
            
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                var trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("//") && !trimmedLine.StartsWith("///")) { }
                else
                {
                    newLines.Add(line);
                }
            }
            for (int i = 0; i < newLines.Count; i++)
            {
                if (newLines[i].Trim().Length == 0)
                {
                    newLines.RemoveAt(i);
                }
            }
            source = string.Join("\n", newLines);
            richTextBox1.Text = source;
            counts_Update(source);
            label2.Text = lineCount.ToString();
            label3.Text = wordCount.ToString();
        }

        private void counts_Update(string _source)
        {
            lineCount = 0;
            wordCount = 0;
            string[] lines = _source.Split('\n');
            lineCount = lines.Length;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                var trimmedLine = line.Trim();
                string[] words = trimmedLine.Split(' ');
                wordCount += words.Length;
            }
        }
    }
}
