using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class WriterListWithBlogCount
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterImage { get; set; } = "/WriterImages/nophoto.png";
        public int BlogCount { get; set; }
    }
}
