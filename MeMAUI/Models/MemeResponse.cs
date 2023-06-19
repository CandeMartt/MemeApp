using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeMAUI.Models.Response
{
    public class MemeResponse
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string url { get; set; }
        public string page_url { get; set; }
    }
}
