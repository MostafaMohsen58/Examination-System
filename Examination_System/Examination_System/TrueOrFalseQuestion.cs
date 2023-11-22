using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueOrFalseQuestion:BaseQuestion
    {
        public TrueOrFalseQuestion(string body, int mark, int _rightAnswer) : base(body, mark)
        {
            Header= "True OR False Question";
            AnswerList = new Answer[3];
            
            Answer answer = new Answer
            {
                AnswerId = 1,
                AnsswerText = "True"
            };
            AnswerList[0] = answer;
            Answer answer2 = new Answer
            {
                AnswerId = 2,
                AnsswerText = "False"
            };
            AnswerList[1]= answer2;
            Answer answer3 = new Answer
            {
                AnswerId = _rightAnswer,
                AnsswerText = _rightAnswer == 1 ? "True" : "False"
            };
            AnswerList[2] = answer3;

        }
        public override string ToString()
        {
            Console.WriteLine($"{this.Header}       Mark:({this.Mark})");
            Console.WriteLine($"{this.Body}");
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"{AnswerList[i].AnswerId }: {AnswerList[i].AnsswerText}       ");
            }        
            Console.WriteLine();
            Console.Write("------------------------------");
            return " ";
        }
    }
}
