using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Role:IEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleStatus { get; set; } = false;
        public List<WriterRole> WriterRoles { get; set; }
    }
}
