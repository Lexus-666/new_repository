using lab3;

internal class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Ksusha", "Ivanova", 16, 2.1);
        Student student2 = new Student("Masha", "Petrova", 14, 3.5);
        Student student3 = new Student("Artem", "Kirillenko", 8, 2.7);

        School school = new School(new List<Student> { student3 });

        school.FindStudent("Ksusha", "Ivanova");
        school.FindStudent("Masha", "Petrova");
        school.FindStudent("Artem", "Kirillenko");

        school.AddStudent(student1);
        school.AddStudent(student2);

        school.FindStudent("Ksusha", "Ivanova");
        school.FindStudent("Masha", "Petrova");
        school.FindStudent("Artem", "Kirillenko");

        school.RemoveStudent(student1);

        school.FindStudent("Ksusha", "Ivanova");

        lab3.DataAccess.StudentsRepository studentsRepository = new lab3.DataAccess.StudentsRepository("studentsRepository.txt");

        studentsRepository.writeStudentsInfo(school);

        studentsRepository.readStudentsInfo();
    }
}

namespace lab3
{
    public class Student
    {

        public Student(string name, string surname, int age, double avgScore)
        {
            Name = name;
            Surname = surname;
            Age = age;
            AverageScore = avgScore;
        }

        // Приватные поля
        private string name;
        private string surname;
        private int age;
        private double averageScore;

        // Публичные свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double AverageScore
        {
            get { return averageScore; }
            set { averageScore = value; }
        }
    }

    public class University
    {
        private List<Student> students;

        // Публичное свойство
        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        public University(List<Student> students)
        {
            Students = students;
        }

        // Добавление студента
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        // Удаление студента
        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        // Поиск студента по имени и фамилии
        public  void FindStudent(string name, string surname)
        {
            bool found = false;
            
            List<Student> searchResults = new List<Student>();

            foreach (Student student in students)
            {
                if (student.Name == name && student.Surname == surname)
                {
                    found = true;
                    searchResults.Add(student);
                }
            }
            if (found)
            {
                foreach (Student student in searchResults)
                {
                    Console.WriteLine($"{student.Name} {student.Surname}");
                }
            }
            else { Console.WriteLine("Ничего не найдено :((("); }
        }
    }

    namespace DataAccess
    {
        public class StudentsRepository
        {
            private string fileName;

            public string Filename 
            {
                get { return fileName; }
                set { fileName = value; }
            }

            public StudentsRepository(string fileName)
            {
                Filename = fileName;
            }
