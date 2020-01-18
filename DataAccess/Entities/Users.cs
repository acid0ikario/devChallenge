using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string rolId { get; set; }

       
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual Roles Role { get; set; }
    }
}
