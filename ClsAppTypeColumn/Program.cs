using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsAppTypeColumn
{
    class Program
    {
        static void Main(string[] args)
        {
            DaoPeople dao = new DaoPeople(Connect.getSqlConnectionInstance);
            People people = new People();
            //people.Name = "Teste 1";
            //people.TimeCreated = TimeSpan.Parse("13:10");
            //people.GuidId = Guid.NewGuid();
            //people.Value = 125.36M;
            //people.DateCreated = DateTime.Now.Date;
            //people.Active = false;

            people = dao.Add(people);
        }
    }
}
