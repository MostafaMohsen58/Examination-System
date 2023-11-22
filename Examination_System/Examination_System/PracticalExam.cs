using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        //public BaseQuestion[] Questions { get; set; }

        public PracticalExam(int examTime, int numQuestions, BaseQuestion[] questions)
        {
            TimeOfExam = examTime;
            NumberOfQuestion = numQuestions;
            Questions = questions;
        }
        public override void ShowExam()
        {
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.Clear();
            Console.WriteLine("Practical Exam:");
           
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine(Questions[i]);
                bool f = false;
            
                int choice;
                do
                {
                    if (sw.Elapsed.TotalMinutes >= TimeOfExam)
                    {
                        f= true;
                        break;
                    }
                } while (!int.TryParse(Console.ReadLine(), out choice) || !(choice >= 1 && choice <= 3));
                 if(f|| sw.Elapsed.TotalMinutes >= TimeOfExam)
                 {
                    break;
                 }
                Console.WriteLine("============================");
                Console.WriteLine();
            }
       
            Console.Clear();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"Q{i + 1}: {Questions[i].Body} ");
                int ind = Questions[i].AnswerList[3].AnswerId - 1;
                Console.WriteLine(Questions[i].AnswerList[ind].AnsswerText);//Questions[i].AnswerList[3]-1
            }
        }
    }
}
