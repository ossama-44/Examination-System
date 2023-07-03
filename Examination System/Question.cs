using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Exam
{
    internal class Question
    {
        public string? QHeader { get; set; }
        public string? QBody { get; set; }
        public int QMark { get; set; }
        public Answer? RightAnswer { get; set; }
        public Answer[]? Answers { get; set; }


        public void GetBody()
        {
            bool flag = true;
            string? value;
            do
            {
                Console.WriteLine("Please Enter The Body Of Question: ");
                value = Console.ReadLine();
                if (value?.Length < 7)
                {
                    flag = false;
                }
                else
                {
                    QBody = value;
                    flag = true;
                }

            } while (flag == false);
        }


        public void GetMark()
        {
            int num = 0;
            bool flag = true;
            do
            {
                Console.Write("Please Enter The Mark Of Question:");
                flag = int.TryParse(Console.ReadLine(), out num);
                QMark = num;
            } while (flag == false || num < 0);

        }

        public virtual void EnterAnswers() { }
        public virtual void EnterRightAnswer() { }

        public virtual int GetSTUAnswer() { return 0; }
      


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Answer answer in Answers)
            {
                sb.AppendFormat($"{answer.AnswerId}. {answer.AnswerText}         ");
            }
            return $"{QHeader}         Mark({QMark})\n {QBody}\n {sb}\n --------------------------------------------------" ;
        }

    }
}
