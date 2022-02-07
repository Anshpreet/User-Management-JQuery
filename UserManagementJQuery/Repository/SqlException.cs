using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementJQuery.Repository
{
    public class SqlException :Exception
    {
        public SqlException(string message, Exception ex): base(message, ex)
        {

        }
    }
}
