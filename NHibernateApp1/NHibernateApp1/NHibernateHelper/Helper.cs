using System;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateApp1.NHibernateHelper
{
    public class Helper
    {
        private static ISessionFactory sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    var configuration = new Configuration();//NHibernate初始化
                    configuration.Configure(); //解析hibernate.cfg.xml文件
                    sessionFactory = configuration.BuildSessionFactory();//连接数据库会话工厂
                }
                return sessionFactory;
            }
        }
        public static ISession GetSession()
        {
            try
            {
                return SessionFactory.OpenSession();//打开一个数据库会话
            }
            catch(Exception ex)
            {
                Console.WriteLine("打开数据库失败" + ex.ToString());
                return null;
            }
        }
        
    }
}
