using System;
using EntityExcel;

namespace EntityExcelDemo
{
    public class Program
    {
        private const string FilePath = "demo.xlsx";

        public static void Main(string[] args)
        {
            var reader = new ExcelReader(FilePath);
            var students = reader.GetMapper<StudentModel>("Students");
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id} \tName: {student.Name} \tGender: {student.Gender} \tGrade: {student.Grade} \tScore: {student.Score}");
            }
            Console.ReadLine();
        }
    }
}