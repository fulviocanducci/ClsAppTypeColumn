using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsAppTypeColumn
{
    public sealed class Connect
    {
        private static SqlConnection _c;
        public static SqlConnection getSqlConnectionInstance
        {
            get
            {
                if (_c == null)
                    _c = new SqlConnection("Server=.\\SQLExpress;Database=myDataBase;User Id=sa;Password=senha;MultipleActiveResultSets=true");
                return _c;                    
            }
        }
    }
}
