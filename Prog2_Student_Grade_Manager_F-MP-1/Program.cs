using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Student_Grade_Manager_F_MP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("data/students_grades.csv"))
                using (StreamWriter database_grades = new StreamWriter("data/students_grades.csv"))
                {
                    database_grades.WriteLine("Student ID,Last Name,First Name, Data Structure, Programming 2, Math Application");
                }

            Console.WriteLine(
                "----[Student Grade Manager]----\n" +
                "[1] Add Student Record\n" +
                "[2] Import new Student Grades\n" +
                "[3] Export Student Grades\n" +
                "[4] Export All Student Grades\n");

            string userInput = Console.ReadLine();
            while (userInput == "1")
            {
                Console.WriteLine("----[Add Student Record]----");
                Console.Write("Student ID: ");
                string stu_ID = Console.ReadLine();
                Console.Write("Lastname: ");
                string stu_LN = Console.ReadLine();
                Console.Write("First Name: ");
                string stu_FN = Console.ReadLine();
                Console.Write("Data Structure Grade: ");
                int stu_DSA;
                if (!int.TryParse(Console.ReadLine(), out stu_DSA))
                {
                    Console.WriteLine("Error Input a Valid Format"); break;
                }
                Console.Write("Programming 2 Grade: ");
                int stu_PROG;
                if (!int.TryParse(Console.ReadLine(), out stu_PROG))
                {
                    Console.WriteLine("Error Input a Valid Format"); break;
                }

                Console.Write("Math Application Grade: ");
                int stu_MATH;
                if (!int.TryParse(Console.ReadLine(), out stu_MATH))
                {
                    Console.WriteLine("Error Input a Valid Format"); break;
                }
                if (!(stu_DSA >= 0 && stu_DSA < 101 && stu_PROG >= 0 && stu_PROG < 101 && stu_MATH >= 0 && stu_MATH < 101))
                {
                    Console.WriteLine("Bad Grade Format"); break;
                }
                string format = $"{stu_ID},{stu_LN},{stu_FN},{stu_DSA},{stu_PROG},{stu_MATH}";
                File.AppendAllText("data/students_grades.csv", format); break;
            }
            while (userInput == "2")
            {
                Console.WriteLine("----[Import Student Grades]----");
                Console.Write("Enter Path: ");
                string user_path = Console.ReadLine();
                if (File.Exists(user_path))
                {
                    Console.WriteLine("\nFile Importing.....\n");
                    string[] data = File.ReadAllLines(user_path);
                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] data_values = data[i].Split(',');
                        int temp = 0;
                        if (!(int.TryParse(data_values[3], out temp)) || !(int.TryParse(data_values[4], out temp)) || !(int.TryParse(data_values[5], out temp)))
                            Console.WriteLine("Invalid Format: Skipping");
                        else
                        {
                            Console.WriteLine($"Importing [{data_values[0]}]'s Data");
                            string format = $"{data_values[0]},{data_values[1]},{data_values[2]},{data_values[3]},{data_values[4]},{data_values[5]}";
                            File.AppendAllText("data/students_grades.csv", format);
                        }
                        
                    }
                    break;
                }
                else
                    Console.WriteLine("File on Path not Found");
            }
            while (userInput == "3")
            {
                Console.WriteLine("----[Export Student Grades]----");
                Console.Write("Enter Student ID: ");
                string user_ID = Console.ReadLine();
                string[] data = File.ReadAllLines("data/students_grades.csv");
                for (int i = 0;i < data.Length;i++)
                {
                    string[] data_values = data[i].Split(',');
                    string format = $"{data_values[0]},{data_values[1]},{data_values[2]},{data_values[3]},{data_values[4]},{data_values[5]}";
                    if (userInput == data_values[0])
                    {
                        File.WriteAllText($"reports/{data_values[1]}, {data_values[2]}.csv", format);
                    }
                }
            }
        }
    }
}
