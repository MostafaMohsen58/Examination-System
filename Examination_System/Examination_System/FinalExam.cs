using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {

        //public BaseQuestion[] Questions { get; set; }
        public int Grade { get; set; }

        public FinalExam(int examTime, int numQuestions, BaseQuestion[] questions)
        {
            TimeOfExam = examTime;
            NumberOfQuestion = numQuestions;
            Questions = questions;
            Grade = 0;
        }

        public override void ShowExam()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.Clear();
            int totalGrade = 0;
            Console.WriteLine("Final Exam:");
            for(int i = 0; i < Questions.Length; i++)
            {
                totalGrade += Questions[i].Mark;
            }
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine(Questions[i]);
                bool f = false;

                int choice=-1000;
                do
                {
                    if (sw.Elapsed.TotalMinutes >= TimeOfExam)
                    {
                        f = true;
                        break;
                    }
                } while (!int.TryParse(Console.ReadLine(), out choice) || !(choice >= 1 && choice <= 3));
                
                Console.WriteLine("============================");

                int ind;
                if (Questions[i].AnswerList.Length == 3)
                {
                    ind = Questions[i].AnswerList[2].AnswerId;
                }
                else
                {
                    ind = Questions[i].AnswerList[3].AnswerId - 1;
                }

                if (choice == ind)
                {
                    Grade += Questions[i].Mark;
                }
                if (f || sw.Elapsed.TotalMinutes >= TimeOfExam)
                {
                    break;
                }
                Console.WriteLine();
            }

            Console.Clear();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"Q{i + 1}: {Questions[i].Body} : ");
                int ind;
                if (Questions[i].AnswerList.Length==3)
                {
                    ind = Questions[i].AnswerList[2].AnswerId - 1;
                }
                else
                {
                    ind = Questions[i].AnswerList[3].AnswerId - 1;
                }
                
                Console.WriteLine(Questions[i].AnswerList[ind].AnsswerText);
            }
            Console.WriteLine($"Your Exam Grade is {Grade} from {totalGrade}");
        }
    }
}
