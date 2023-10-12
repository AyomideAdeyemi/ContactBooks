using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        //Relationship

        public ICollection<Contact> Contacts { get; set;}
    }
}
