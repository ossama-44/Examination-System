using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Exam
    {
        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] questions { get; set; }

        public Exam() { }

        public int GetTime()
        {
            bool flag = true;
            int time = 0;
            do
            {
                Console.Write("Please Enter The Time Of Exam In Minutes : ");
                flag = int.TryParse(Console.ReadLine(), out time);
            } while (flag == false || time < 1);
            return time;
        }

        public int GetNumberOfQuestions()
        {
            bool flag = true;
            int num = 0;
            do
            {
                Console.Write("Please Enter The The Number Of Question You Want To Create : ");
                flag = int.TryParse(Console.ReadLine(), out num);
            } while (flag == false || num < 1);
            return num;
        }

        public void Practical()
        {
            TimeOfExam =TimeSpan.FromMinutes(GetTime());
            NumberOfQuestions = GetNumberOfQuestions();
            Console.Clear();
            questions = new Question[NumberOfQuestions]; 
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                questions[i] = new MCQ();
                Console.WriteLine($"Please Enter The Question Number ({i+1})");
                Console.WriteLine(questions[i].QHeader);
                questions[i].GetBody();
                questions[i].GetMark();
                questions[i].EnterAnswers();
                questions[i].EnterRightAnswer();
            }


        }

        public void Final()
        {
            TimeOfExam = TimeSpan.FromMinutes(GetTime());
            NumberOfQuestions = GetNumberOfQuestions();
            questions = new Question[NumberOfQuestions];
            Console.Clear();
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int ExType = -1;
                do
                {
                    ExType = CheckQType(GetQType(i+1));
                } while (ExType == -1);

                if (ExType == 1)
                {
                    questions[i] = new TrueOrFalse();
                }
                else
                {
                    questions[i] = new MCQ();        
                }
                Console.Clear();
                Console.WriteLine(questions[i].QHeader);
                questions[i].GetBody();
                questions[i].GetMark();
                questions[i].EnterAnswers();
                questions[i].EnterRightAnswer();

            }
        }

        public int GetQType(int QN)
        {
            bool flag = true;
            int ExType;
            do
            {
                Console.Write($"Please Choice The Type Of Question Number ({QN}) You Want To Create ( 1 For True | False and 2 For MCQ ) : ");
                flag = int.TryParse(Console.ReadLine(), out ExType);
            } while (flag == false);
            return ExType;
        }

        public int CheckQType(int type)
        {
            if (type == 1)
                return type;
            else if (type == 2)
                return type;
            else
                return -1;
        }

        public void ShowExam()
        {
            int aID = 0, gread = 0, totalGread = 0 ;
            int[] anss = new int[questions.Length];
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i].ToString());
                totalGread += questions[i].QMark;
                aID = questions[i].GetSTUAnswer();
                anss[i] = aID;
                if (aID == questions[i].RightAnswer.AnswerId)
                    gread += questions[i].QMark;
                Console.WriteLine();
                Console.WriteLine("=========================================================================");

            }

            Console.Clear();
            Console.WriteLine("Your Answers : ");
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"{questions[i].QBody} :  {Search(questions[i].Answers, anss[i])}");
            }
            Console.WriteLine($"Your Exam Gread is {gread} From {totalGread}");
        }

        public string Search(Answer[] arr, int x)
        {
            int indexx = 0;
            for (int i = 0; indexx < arr.Length; i++)
            {
                if (arr[i].AnswerId == x)
                    return arr[i].AnswerText;
            }
            return "";
        }
    }
}
