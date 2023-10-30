using System.Data;

namespace StudentManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbManager = new DatabaseManager();

            // 创建学校
            var school = new School { Name = "School A" };
            dbManager.CreateSchool(school);

            // 创建班级
            var @class = new Class { Name = "Class 1", SchoolId = school.Id };
            dbManager.CreateClass(@class);

            // 创建学生
            var student = new Student { Name = "John Doe", ClassId = @class.Id };
            dbManager.CreateStudent(student);

            // 查询学校信息
            var schools = dbManager.GetSchools();
            foreach (var s in schools)
            {
                Console.WriteLine($"School ID: {s.Id}, Name: {s.Name}");
            }

            // 查询班级信息
            var classes = dbManager.GetClasses(school.Id);
            foreach (var c in classes)
            {
                Console.WriteLine($"Class ID: {c.Id}, Name: {c.Name}");
            }

            // 查询学生信息
            var students = dbManager.GetStudents(@class.Id);
            foreach (var s in students)
            {
                Console.WriteLine($"Student ID: {s.Id}, Name: {s.Name}");
            }

            // 删除学生
            dbManager.DeleteStudent(student.Id);

            // 查询日志信息
            var logData = dbManager.GetLogData();
            foreach (DataRow row in logData.Rows)
            {
                var action = row["Action"].ToString();
                var dateTime = row["DateTime"].ToString();
                Console.WriteLine($"Action: {action}, DateTime: {dateTime}");
            }

            // 记录日志
            dbManager.LogAction("User performed an action");

        }
    }
}