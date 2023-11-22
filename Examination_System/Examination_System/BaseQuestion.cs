using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class BaseQuestion
    {
        public  string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public  Answer[] AnswerList { get; set; }
        
        public BaseQuestion(string _body, int _mark)
        {
            Body = _body;
            Mark = _mark;
        }
    }
}
