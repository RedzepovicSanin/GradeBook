using System;
using System.IO;

namespace Grades
{
    class MainClass
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook(); // instantiate object by calling method

            // GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        static IGradeTracker CreateGradeBook()  // creating ThrowAwayGradeBook type object
        {
            return new ThrowAwayGradeBook();
        }



        static void GetBookName(IGradeTracker book) // generating a name for object book
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        static void AddGrades(IGradeTracker book) // adding grades to object book
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.AddGrade(50);
            book.AddGrade(99);
        }

        static void SaveGrades(IGradeTracker book)  // saving grades to file
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                outputFile.Close();
            }
        }

        static void WriteResults(IGradeTracker book) // writing different results in console
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        static void WriteResult(string description, string result) // helper method
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result) // helper method 
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
    }
}