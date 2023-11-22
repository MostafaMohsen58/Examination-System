using Examination_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam _Exam { get; set; }
        public Subject(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
        public void CreateMcqQuestion(int index,ref BaseQuestion[] questions)
        {
            Console.WriteLine("Choose One Answer Question");
            string? questionBody;
            do
            {
                Console.Write("Please Enter the question body: ");
                questionBody = Console.ReadLine();
            } while (questionBody == "");
            int questionMark=0;
            do
            {
                Console.Write("Please Enter the question mark: ");
            } while (!int.TryParse(Console.ReadLine(), out questionMark)|| !(questionMark>0));


            Answer[] answeroptions = new Answer[4];
            Console.WriteLine("The Choices of Question is: ");
            for (int m = 0; m < 3;)
            {
                string? answerText;
                do
                {
                    Console.Write($"Please Enter Choice Number {m + 1}: ");
                    answerText = Console.ReadLine();
                } while (answerText == "");

                Answer answer = new Answer
                {
                    AnswerId = m ,
                    AnsswerText = answerText
                };
                answeroptions[m] = answer;
                m++;
            }

            int rightChoice;
            do
            {
                Console.WriteLine("Please specify The Right Answer Of Question: ");
            } while (!int.TryParse(Console.ReadLine(), out rightChoice) || !(rightChoice >= 1 && rightChoice <= 3));
            string rightAns = answeroptions[rightChoice - 1].AnsswerText;
            Answer Rranswer = new Answer
            {
                AnswerId = rightChoice,
                AnsswerText = rightAns
            };
            answeroptions[3] = Rranswer;
            questions[index] = new McqQuestion(questionBody, questionMark, answeroptions);
            Console.Clear();
        }
    
        public void CreateExam()
        {
            
            int examTypeChoice;
            do
            {
                Console.Write("Please Enter Type Of Exam You Want To Create( 1 for Practical and 2 for Final):");
            } while (!int.TryParse(Console.ReadLine(), out examTypeChoice) || !(examTypeChoice == 1 || examTypeChoice == 2));
            int examTime = 0;
            do
            {
                Console.Write("Please Enter the time of Exam in Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out examTime) || !(examTime > 0));
            int numQuestions=-1;
            do
            {
                Console.Write("Please Enter the number of questions You Wanted To Create: ");
            } while (!int.TryParse(Console.ReadLine(), out numQuestions)||!(numQuestions>0));




            Console.Clear();



            // Create an array to store the questions
            BaseQuestion[] questions = new BaseQuestion[numQuestions];
            


            if (examTypeChoice == 2)//final
            {
                for (int i = 0; i < numQuestions; i++)
                {

                    int type;
                    do
                    {
                        Console.WriteLine($"Please Choose The Type Of Question Number({i + 1}) (1 for True OR False ||2 For MCQ)");
                    } while (!int.TryParse(Console.ReadLine(), out type) || !(type == 1 || type == 2));

                    Console.Clear();



                    if (type == 1)//TrueOrFalse Question
                    {
                        Console.WriteLine("True OR False Question");
                        string? questionBody;
                        do
                        {
                            Console.Write("Please Enter the question body: ");
                            questionBody = Console.ReadLine();
                        } while (questionBody is null);

                        int questionMark=0;
                        do
                        {
                            Console.Write("Please Enter the question mark: ");
                        } while (!int.TryParse(Console.ReadLine(), out questionMark)||!(questionMark>0));
                        int trueOrFalse;
                        do
                        {
                            Console.Write("Please Enter The Right Answer of Question (1 for true and 2 for false):");
                        } while (!int.TryParse(Console.ReadLine(), out trueOrFalse) || !(trueOrFalse == 1 || trueOrFalse == 2));


                        questions[i] = new TrueOrFalseQuestion(questionBody, questionMark, trueOrFalse);
                        Console.Clear();
                    }
                    else//MCQ Question
                    {       
                        CreateMcqQuestion(i, ref questions);
                    }
                }
            }
            else//practical
            {
                for (int i = 0; i < numQuestions; i++)
                {
                    CreateMcqQuestion(i,ref questions);
                
                }
            }


            Exam exam;
            if (examTypeChoice == 2)
            {
                // Final Exam
                exam = new FinalExam(examTime, numQuestions, questions);
            }
            else
            {
                // Practical Exam
                exam = new PracticalExam(examTime, numQuestions, questions);
            }
            _Exam = exam;

        }

    }
}


















//int TypeOfExam;
//do
//{
//    Console.WriteLine($"Enter Type Of Exam To create (1 for Practical and 2 for Final): ");
//} while (!int.TryParse(Console.ReadLine(), out TypeOfExam));
//int Time;
//do
//{
//    Console.WriteLine("Please Enter The Time Of Exam in Minutes");
//} while (!int.TryParse(Console.ReadLine(), out Time));
//int NumberOfQuestion;
//do
//{
//    Console.WriteLine("Please Enter The Number of Question you want create");
//} while (!int.TryParse(Console.ReadLine(), out NumberOfQuestion));

//if (TypeOfExam == 2)
//{
//    FinalExam exam = new FinalExam(Time, NumberOfQuestion);
//    Question[] finalExamQuestions;
//    for (int i = 0; i < NumberOfQuestion;)
//    {
//        int R;
//        Console.WriteLine("Please Entre Type Of Question 1=>true or false 2=>MCQ ");
//        i = int.TryParse(Console.ReadLine(), out R) == true && (R == 1 || R == 2) ? i++ : i;
//        //if (R == 1)
//        //{
//        //    Console.WriteLine("enter Question Body");
//        //    string b=Console.ReadLine();
//        //    Console.WriteLine("Entre Mark");
//        //    int m = int.Parse(Console.ReadLine());
//        //    Console.WriteLine("Entre Right Answer");
//        //        int r = int.Parse(Console.ReadLine());
//        //    finalExamQuestions = new Question[]
//        //    {
//        //        new TrueOrFalseQuestion(b, m,1)
//        //    };
//        //}
//        //else
//        //{

//        //}
//    }
//}
//else
//{
//    PracticalExam ex = new PracticalExam(Time, NumberOfQuestion);
//}
