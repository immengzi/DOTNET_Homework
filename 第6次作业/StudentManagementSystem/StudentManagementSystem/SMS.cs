using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Security.Claims;

namespace StudentManagementSystem
{
    public class DatabaseManager
    {
        private const string ConnectionString = "Data Source=students.db;Version=3;";

        public DatabaseManager()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var createSchoolsTable = @"CREATE TABLE IF NOT EXISTS Schools (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL
            );";

                var createClassesTable = @"CREATE TABLE IF NOT EXISTS Classes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                SchoolId INTEGER NOT NULL,
                FOREIGN KEY (SchoolId) REFERENCES Schools(Id)
            );";

                var createStudentsTable = @"CREATE TABLE IF NOT EXISTS Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                ClassId INTEGER NOT NULL,
                FOREIGN KEY (ClassId) REFERENCES Classes(Id)
            );";

                var createLogTable = @"CREATE TABLE IF NOT EXISTS Log (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Action TEXT NOT NULL,
                DateTime TEXT NOT NULL
            );";

                var command = connection.CreateCommand();
                command.CommandText = createSchoolsTable;
                command.ExecuteNonQuery();

                command.CommandText = createClassesTable;
                command.ExecuteNonQuery();

                command.CommandText = createStudentsTable;
                command.ExecuteNonQuery();

                command.CommandText = createLogTable;
                command.ExecuteNonQuery();
                var clearLogTable = "DELETE FROM Log";

                command.CommandText = clearLogTable;
                command.ExecuteNonQuery();

            }

        }

        public void CreateSchool(School school)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Schools (Name) VALUES (@Name)";
                command.Parameters.AddWithValue("@Name", school.Name);
                command.ExecuteNonQuery();
            }
        }

        public void CreateClass(Class @class)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Classes (Name, SchoolId) VALUES (@Name, @SchoolId)";
                command.Parameters.AddWithValue("@Name", @class.Name);
                command.Parameters.AddWithValue("@SchoolId", @class.SchoolId);
                command.ExecuteNonQuery();
            }
        }

        public void CreateStudent(Student student)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Students (Name, ClassId) VALUES (@Name, @ClassId)";
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@ClassId", student.ClassId);
                command.ExecuteNonQuery();
            }
        }

        public List<School> GetSchools()
        {
            var schools = new List<School>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Schools";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var school = new School
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString()
                    };
                    schools.Add(school);
                }
            }
            return schools;
        }

        public List<Class> GetClasses(int schoolId)
        {
            var classes = new List<Class>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Classes WHERE SchoolId = @SchoolId";
                command.Parameters.AddWithValue("@SchoolId", schoolId);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var @class = new Class
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        SchoolId = Convert.ToInt32(reader["SchoolId"])
                    };
                    classes.Add(@class);
                }
            }

            return classes;
        }

        public List<Student> GetStudents(int classId)
        {
            var students = new List<Student>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Students WHERE ClassId = @ClassId";
                command.Parameters.AddWithValue("@ClassId", classId);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        ClassId = Convert.ToInt32(reader["ClassId"])
                    };
                    students.Add(student);
                }
            }

            return students;
        }

        public void DeleteSchool(int schoolId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Schools WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", schoolId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteClass(int classId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Classes WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", classId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Students WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", studentId);
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetLogData()
        {
            var logData = new DataTable();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Log";
                var adapter = new SQLiteDataAdapter(command);
                adapter.Fill(logData);
            }

            return logData;
        }

        public void LogAction(string action)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Log (Action, DateTime) VALUES (@Action, @DateTime)";
                command.Parameters.AddWithValue("@Action", action);
                command.Parameters.AddWithValue("@DateTime", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }
    }

    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
    }

}
