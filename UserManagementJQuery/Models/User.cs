using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagementJQuery.Models
{
    public partial class User
    {
       
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public bool IsDeleted { get; set; }

       
    }
}
