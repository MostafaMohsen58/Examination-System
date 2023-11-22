using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestion { get; set; }
        public BaseQuestion[] Questions { get; set; }
        public abstract void ShowExam();

    }
}
