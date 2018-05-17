using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        protected List<float> grades;

        public override IEnumerator GetEnumerator() 
        {
            return grades.GetEnumerator();
        }

        public GradeBook() // constructor
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)                      // iterating through grades list
            {
                destination.WriteLine(grades[i]);
            }
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics() 
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades) 
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade); // setting highest grade
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);  // setting lowest grade

                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
    }
}