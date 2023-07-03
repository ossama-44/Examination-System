using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubExam { get; set; }

        public Subject( int id, string name) 
        {
            SubjectId = id;
            SubjectName = name;
            SubExam = new Exam();
        }

        public void CreateExam()
        {
            int ExType = -1;
            do
            {
                ExType = CheckType(GetExType());
            }while (ExType == -1);

            if (ExType == 1)
            {
                SubExam.Practical();
            }
            else
            {
                SubExam.Final();
            }
            

            
        }


        public int GetExType() 
        {
            bool flag = true;
            int ExType ;
            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create ( 1 For Practical and 2 For Final ) : ");
                flag = int.TryParse(Console.ReadLine(), out ExType);
            } while (flag == false);
            return ExType;
        }

        public int CheckType(int type)
        {
            if (type == 1)
                return type;
            else if (type == 2)
                return type;
            else
                return -1;
        }


    }


}
