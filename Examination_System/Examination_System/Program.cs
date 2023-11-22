using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10, "C#");
            sub1.CreateExam();

            Console.Clear();
            Console.Write("Do you want To Start the Exam (y|n): ");

            char input;
            do
            {
            }while(!char.TryParse(Console.ReadLine(), out input)|| !(input=='y'||input=='n'|| input == 'N' || input == 'Y'));
            if (input == 'y'|| input == 'Y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub1._Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time ={sw.Elapsed}");
            }

        }
    }
}