using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterRole:IEntity
    {
        [Key]
        public int WriterRoleId { get; set; }
        public int WriterId { get; set; }
        public int RoleId { get; set; }
        public Writer Writer { get; set; }
        public Role Role { get; set; }
    }
}
