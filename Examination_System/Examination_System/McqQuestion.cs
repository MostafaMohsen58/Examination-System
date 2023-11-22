using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class McqQuestion : BaseQuestion
    {
        public McqQuestion(string body, int mark, Answer[] answerList) : base(body, mark)
        {
            AnswerList= answerList;
            Header = "Choose One Answer Question";
        }
        public override string ToString()
        {
            Console.WriteLine($"{this.Header}       Mark:({this.Mark})");
            Console.WriteLine($"{this.Body}");
            for (int i = 0; i < 3; i++)
            {
               Console.Write($"{AnswerList[i].AnswerId + 1}: {AnswerList[i].AnsswerText}       ");
            }
            Console.WriteLine();
            Console.Write("------------------------------");
            return " ";
        }
    }
}
