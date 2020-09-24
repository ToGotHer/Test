using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateApp1.StudentClass
{
    class Student
    {
        public virtual int Stuid { get; set; }
        public virtual string Stuname { get; set; }
        public virtual int Stuscore { get; set; }

    }
}
