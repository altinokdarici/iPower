using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPower.Phone.Models
{
    public class Response
    {
        public string Description { get; set; }
        public ObservableCollection<Models.Item> TimeLine { get; set; }
        public ObservableCollection<Models.Item> History { get; set; }
    }

}
