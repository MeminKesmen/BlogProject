using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; } = "Bilgi Yok";
        public string WriterImage { get; set; } = "/WriterImages/nophoto.png";
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; } = true;
        public List<Blog> Blogs { get; set; }
        public List<WriterRole> WriterRoles { get; set; }
        public virtual ICollection<Message> WriterSenders { get; set; }
        public virtual ICollection<Message> WriterReceivers { get; set; }
    }
}
