using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Roles
    {

        [Key]
        public string rolId { get; set; }
        public string description { get; set; }
    
       
        public virtual ICollection<Users> Users { get; set; }
    }
}
