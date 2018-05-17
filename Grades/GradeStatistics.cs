﻿using System;
namespace Grades
{
    public class GradeStatistics
    {
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public string Description 
        {
            get 
            {
                string result;
                switch(LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below average";
                        break;
                    default:
                        result = "Failing";
                        break;
                        
                }
                return result;
            }
        }

        public string LetterGrade 
        {
            get 
            {
                string result;
                if (AverageGrade >= 90) {
                    result = "A";
                } 
                else if (AverageGrade >= 80)
                {
                    result = "B";
                } 
                else if (AverageGrade >= 70)
                {
                    result = "C";
                } 
                else if (AverageGrade >= 60)
                {
                    result = "D";
                }
                else {
                    result = "F";
                }
                return result;
            }
        }

        public GradeStatistics() //constructor
        {
            HighestGrade = float.MinValue;
            LowestGrade = float.MaxValue;
        }
    }
}