using System.Diagnostics;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();
            Console.Write("Do you Want to start The Exam (y | n): ");

            if( char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                subject.SubExam.ShowExam();
                Console.WriteLine($"The Elapased Time {sw.Elapsed}");
            }
;
        }
    }
}