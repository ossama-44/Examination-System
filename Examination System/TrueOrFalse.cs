using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Exam
{
    internal class TrueOrFalse : Question
    {
        public TrueOrFalse() : base()
        {
            QHeader = "True | False Question";
            Answers = new Answer[2];
            RightAnswer = new Answer();
        }

        public override void EnterAnswers()
        {
            Answers[0] = new Answer();
            Answers[0].AnswerText = "True";
            Answers[0].AnswerId = 1;
            Answers[1] = new Answer();
            Answers[1].AnswerText = "False";
            Answers[1].AnswerId = 2;
        }

        public override void EnterRightAnswer()
        {
            bool flag = true;
            int answerId = 0;
            do
            {
                Console.WriteLine("Please Entwr The Right Answer of Question ( 1 for True and 2  for Fulse): ");
                flag = int.TryParse(Console.ReadLine(), out answerId);
            } while (flag == false || (answerId < 1 || answerId > 2));
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
            } while (flag == false || (answerId < 1 || answerId > 2));
            return answerId;
        }
    }
    
}
