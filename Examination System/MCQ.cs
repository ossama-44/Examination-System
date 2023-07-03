using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class MCQ :Question
    {
        public MCQ() : base()
        {
            QHeader = "Choices One Answer Question";
            Answers = new Answer[3];
            RightAnswer = new Answer();
        }

        public override void EnterAnswers()
        {
            string ? answerText = " ";
            Console.WriteLine("The Choices of Question : ");
            for (int i = 0; i < Answers?.Length; i++)
            {
                Answers[i] = new Answer(); 
                Console.Write($"Please Enter The Choices number ({i + 1}) : ");
                answerText = Console.ReadLine();
                Answers[i].AnswerText = answerText; 
                Answers[i].AnswerId = i + 1;

            }
        }
        public override void EnterRightAnswer()
        {
            bool flag = true;
            int answerId = 0;
            do
            {
                Console.WriteLine("Please Specify The Right Choices of Question :");
                flag = int.TryParse(Console.ReadLine(), out answerId);
            } while (flag == false || (answerId < 1 || answerId > 3));
            RightAnswer.AnswerId = answerId;
            Console.Clear();
        }

        public override int GetSTUAnswer()
        {
            bool flag = true;
            int answerId = 0;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out answerId);
            } while (flag == false || (answerId < 1 || answerId > 3));
            return answerId;
        }
    }
}
