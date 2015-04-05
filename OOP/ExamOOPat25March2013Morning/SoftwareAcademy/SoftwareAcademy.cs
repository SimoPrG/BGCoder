using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.Reflection;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    internal static class Validator
    {
        public static void CheckStringIfNullOrWhiteSpace(string str, string message)
        {
            if(string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(str, message);
        }
    }

    public class Teacher : ITeacher
    {
        private string name;

        private readonly ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                Validator.CheckStringIfNullOrWhiteSpace(value, "The name cannot be null or white spaces.");
                name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            var coursesString =
                this.courses.Count == 0
                ? "" : string.Format("; Courses=[{0}]", string.Join(", ", this.courses.Select(c => c.Name)));
            return string.Format("Teacher: Name={0}{1}", this.Name, coursesString);
        }
    }


    public abstract class Course : ICourse
    {
        private readonly ICollection<string> topics;
        private string name;

        protected Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckStringIfNullOrWhiteSpace(value, "The name cannot be null or white spaces.");
                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            var teacherString = this.Teacher == null ? "" : string.Format("; Teacher={0}", this.Teacher.Name);
            var topicsString = this.topics.Count == 0 ? "" : string.Format("; Topics=[{0}]", string.Join(", ", this.topics));

            return string.Format(
                "{0}: Name={1}{2}{3}",
                this.GetType().Name,
                this.Name,
                teacherString,
                topicsString);
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return lab;
            }

            set
            {
                Validator.CheckStringIfNullOrWhiteSpace(value, "The lab cannot be null or white spaces.");
                lab = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Lab={0}", this.Lab);
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return town;
            }

            set
            {
                Validator.CheckStringIfNullOrWhiteSpace(value, "The town cannot be null or white spaces.");
                town = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Town={0}", this.Town);
        }
    }
}
