using System;
using NHibernateApp1.StudentManage;

namespace NHibernateApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome!\n\n【1】新建学生 【2】删除学生 【3】更新学生\n【4】查询单个\n【5】查询全部 【6】正序排列\n【7】逆序排列 【0】退出程序\n");
                Console.WriteLine("Please enter a number, if exit please enter Q: \n");
                string Operation = Console.ReadLine();
                if (Operation == "1")
                { 
                    StudentManager.AddStudent();
                }
                else if (Operation == "2")
                {
                    StudentManager.DeleteStudent();
                }
                else if (Operation == "3")
                {
                    StudentManager.UpdateStudent();
                }
                else if (Operation == "4")
                {    
                   StudentManager.FindSingleStudent();
                }
                else if (Operation == "5")
                {     
                    StudentManager.FindAllStudent();                
                }
                else if (Operation == "6")
                {
                  
                    Console.WriteLine("\nThe result of order by asc is: \n");
                    StudentManager.OrderScoreAsc();
                    Console.WriteLine();
                }
                else if (Operation == "7")
                {
                    
                    Console.WriteLine("\nThe result of order by desc is: \n");
                    StudentManager.OrderScoreDesc();
                    Console.WriteLine();
                }
                else if (Operation == "0")
                {
                    Console.WriteLine("\nGoodbye! \n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nYour input is wrong ! Exit\n");
                    break;
                }

            }
            Console.ReadKey();
        }


    }
}
