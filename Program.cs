using System;

namespace ConsoleApp11
{
    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public string PrintDetails()
        {
            return "Course ID: " + CourseId + ", Title: " + Title + ", Instructor: " + (Instructor != null ? Instructor.Name : "None");
        }
    }

    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public string PrintDetails()
        {
            return "Instructor ID: " + InstructorId + ", Name: " + Name + ", Specialization: " + Specialization;
        }
    }

    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public Course[] Courses = new Course[10];
        int courseCount = 0;

        public bool Enroll(Course course)
        {
            if (courseCount < 10)
            {
                Courses[courseCount] = course;
                courseCount++;
                return true;
            }
            return false;
        }

        public bool IsEnrolledInCourse(string courseTitle)
        {
            for (int i = 0; i < courseCount; i++)
            {
                if (Courses[i] != null && Courses[i].Title == courseTitle)
                {
                    return true;
                }
            }
            return false;
        }

        public string PrintDetails()
        {
            string c = "";
            for (int i = 0; i < courseCount; i++)
            {
                c += Courses[i].Title + ", ";
            }
            return "ID: " + StudentId + ", Name: " + Name + ", Age: " + Age + ", Courses: " + c;
        }
    }

    class SchoolStudentManager
    {
        Student[] students = new Student[100];
        Course[] courses = new Course[100];
        Instructor[] instructors = new Instructor[100];

        int studentCount = 0;
        int courseCount = 0;
        int instructorCount = 0;

        public bool AddStudent(Student s)
        {
            if (studentCount < 100)
            {
                students[studentCount] = s;
                studentCount++;
                return true;
            }
            return false;
        }

        public bool AddCourse(Course c)
        {
            if (courseCount < 100)
            {
                courses[courseCount] = c;
                courseCount++;
                return true;
            }
            return false;
        }

        public bool AddInstructor(Instructor i)
        {
            if (instructorCount < 100)
            {
                instructors[instructorCount] = i;
                instructorCount++;
                return true;
            }
            return false;
        }

        public Student FindStudent(int id)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentId == id)
                    return students[i];
            }
            return null;
        }

        public Course FindCourse(int id)
        {
            for (int i = 0; i < courseCount; i++)
            {
                if (courses[i].CourseId == id)
                    return courses[i];
            }
            return null;
        }

        public Instructor FindInstructor(int id)
        {
            for (int i = 0; i < instructorCount; i++)
            {
                if (instructors[i].InstructorId == id)
                    return instructors[i];
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student s = FindStudent(studentId);
            Course c = FindCourse(courseId);
            if (s != null && c != null)
            {
                return s.Enroll(c);
            }
            return false;
        }

        public string GetInstructorNameByCourseTitle(string title)
        {
            for (int i = 0; i < courseCount; i++)
            {
                if (courses[i] != null && courses[i].Title == title)
                {
                    if (courses[i].Instructor != null)
                        return courses[i].Instructor.Name;
                    else
                        return "No instructor for this course";
                }
            }
            return "Course not found";
        }

        public void ShowAllStudents()
        {
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine(students[i].PrintDetails());
            }
        }

        public void ShowAllCourses()
        {
            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine(courses[i].PrintDetails());
            }
        }

        public void ShowAllInstructors()
        {
            for (int i = 0; i < instructorCount; i++)
            {
                Console.WriteLine(instructors[i].PrintDetails());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SchoolStudentManager manager = new SchoolStudentManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2.  Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8.  Check if student enrolled in specific course");
                Console.WriteLine("9.   Get instructor name by course title");
                Console.WriteLine("10. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Student s = new Student();
                    Console.Write("Student ID: ");
                    s.StudentId = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    s.Name = Console.ReadLine();
                    Console.Write("Age: ");
                    s.Age = int.Parse(Console.ReadLine());
                    manager.AddStudent(s);
                }
                else if (choice == "2")
                {
                    Instructor i = new Instructor();
                    Console.Write("Instructor ID: ");
                    i.InstructorId = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    i.Name = Console.ReadLine();
                    Console.Write("Specialization: ");
                    i.Specialization = Console.ReadLine();
                    manager.AddInstructor(i);
                }
                else if (choice == "3")
                {
                    Course c = new Course();
                    Console.Write("Course ID: ");
                    c.CourseId = int.Parse(Console.ReadLine());
                    Console.Write("Title: ");
                    c.Title = Console.ReadLine();
                    Console.Write("Instructor ID: ");
                    int iid = int.Parse(Console.ReadLine());
                    c.Instructor = manager.FindInstructor(iid);
                    manager.AddCourse(c);
                }
                else if (choice == "4")
                {
                    Console.Write("Student ID: ");
                    int sid = int.Parse(Console.ReadLine());
                    Console.Write("Course ID: ");
                    int cid = int.Parse(Console.ReadLine());
                    manager.EnrollStudentInCourse(sid, cid);
                }
                else if (choice == "5")
                {
                    manager.ShowAllStudents();
                }
                else if (choice == "6")
                {
                    manager.ShowAllCourses();
                }
                else if (choice == "7")
                {
                    manager.ShowAllInstructors();
                }
                else if (choice == "8")
                {
                    Console.Write("Student ID: ");
                    int sid = int.Parse(Console.ReadLine());
                    Student s = manager.FindStudent(sid);
                    if (s != null)
                    {
                        Console.Write("Enter course title: ");
                        string title = Console.ReadLine();
                        if (s.IsEnrolledInCourse(title))
                            Console.WriteLine("Yes, student is enrolled in " + title);
                        else
                            Console.WriteLine("No, student is not enrolled in " + title);
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                }
                else if (choice == "9")
                {
                    Console.Write("Enter course title: ");
                    string t = Console.ReadLine();
                    string name = manager.GetInstructorNameByCourseTitle(t);
                    Console.WriteLine("Instructor: " + name);
                }
                else if (choice == "10")
                {
                    running = false;
                }
            }
        }
    }
}
