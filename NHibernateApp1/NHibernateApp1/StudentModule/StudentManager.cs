using System;
using System.Collections.Generic;
using NHibernateApp1.StudentClass;
using NHibernate;
using NHibernateApp1.NHibernateHelper;
using NHibernate.Criterion;

namespace NHibernateApp1.StudentManage
{
    class StudentManager
    {
        private static readonly ISession session = Helper.GetSession();
        //public static  Isession session { get; set; }
     
        //添加
        public static void AddStudent()
        {
            Console.WriteLine("\nPlease enter student's name: \n");
            string stuname = Console.ReadLine();
            Console.WriteLine("\nPlease enter student's score: \n");
            int stuscore = Convert.ToInt32(Console.ReadLine());
            using (ITransaction transaction = session.BeginTransaction())
            {       
                try
                {
                    Student stu = new Student() { Stuname = stuname, Stuscore = stuscore };                    
                    session.Save(stu);
                    session.Flush();
                    transaction.Commit();
                    Console.WriteLine("\nAdd student success !\n");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Add student failed ! {ex.Message}");
                }
            }
          
        }
        //删除
        public static void DeleteStudent()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var res = FindStudentByName();
                    if (res != null)
                    {
                        session.Delete(res);
                        session.Flush();
                        transaction.Commit();
                        Console.WriteLine("\nDelete student success !\n");
                    }
                    else
                        Console.WriteLine("\nCan't delete a null student !\n");
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Delete student failed ! {ex.Message}");
                }
            }
        }
        //修改
        public static void UpdateStudent()
        {
            Console.WriteLine("\nPlease enter student's score: \n");
            int stuscore = Convert.ToInt32(Console.ReadLine());
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var res = FindStudentByName();
                    if (res != null)
                    {
                        res.Stuscore = stuscore;
                        session.Update(res);
                        session.Flush();
                        transaction.Commit();
                        Console.WriteLine("\nUpdate student success !\n");
                    }
                    else
                        Console.WriteLine("\nCan't update a null student !\n");

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Update student failed ! {ex.Message}");
                }
            }
        }
        //根据id查询
        public static Student FindStudentById()
        {
            Console.WriteLine("\nPlease enter student's id: \n");
            int stuid = Convert.ToInt32(Console.ReadLine());
            try
            {
                Student studentObj = session.Get<Student>(stuid);
                return studentObj;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Work error ! {ex.Message}");
                return null;
            }
        }
        //根据名称查询
        public static Student FindStudentByName()
        {
            Console.WriteLine("\nPlease enter student's name: \n");
            string stuname = Console.ReadLine();
            try
            {
                var studentObj = session.CreateCriteria(typeof(Student))
                     .Add(Restrictions.Eq("Stuname", stuname))
                     .UniqueResult<Student>();
                return studentObj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Work error ! {ex.Message}");
                return null;
            }
        }
        //查询单个学生
        public static void FindSingleStudent()
        {
            Console.WriteLine("\nPlease enter operation, 'i' query by id, 'n' query by name: \n");
            string operaton = Console.ReadLine();
            if (operaton == "i")
            {
                Student res1 = FindStudentById();
                if (res1 == null)
                    Console.WriteLine($"\nCan't query a null student !\n");
                else
                    Console.WriteLine($"\nThis student's score is {res1.Stuscore}\n");

            }
            else if (operaton == "n")
            {
                Student res2 = FindStudentByName();
                if (res2 == null)
                    Console.WriteLine($"\nCan't query a null student !\n");
                else
                    Console.WriteLine($"\nThis student's score is {res2.Stuscore}\n");

            }
            else
                Console.WriteLine($"\nThis student doesn't exist !\n");

        }
        //查询全部数据
        public static void FindAllStudent()
        {
            Console.WriteLine("\nThe result of find all student is: \n");
            try
            {
                IList<Student> studentList = session.CreateCriteria(typeof(Student)).List<Student>();
                foreach (var i in studentList)
                {
                    Console.WriteLine($"{i.Stuname} --> {i.Stuscore}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Work error ! {ex.Message}");
            }
            Console.WriteLine();
        }
        //正序排序
        public static void OrderScoreAsc()
        {
            try
            {
                IList<Student> studentList = session.CreateCriteria(typeof(Student))
                    .AddOrder(new Order("Stuscore", true))
                    .List<Student>();
                foreach (var i in studentList)
                {
                    Console.WriteLine($"{i.Stuname} --> {i.Stuscore}");
                }  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Work error ! {ex.Message}");
            }
        }
        //逆序排序
        public static void OrderScoreDesc()
        {
            try
            {
                IList<Student> studentList = session.CreateQuery("from Student s order by Stuscore desc").List<Student>();
                foreach(var i in studentList)
                {
                    Console.WriteLine($"{i.Stuname} --> {i.Stuscore}");
                }           
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Work error ! {ex.Message}");
            }
        }
    }
}
