using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers.Authentication
{
    public class CustomerHelperClass
    {
        public static string userLocalHost { get; set; }
        public static int countNumOfEntries { get; set; }
        public static DateTime customerTimeForCount { get; set; }
        public static DateTime customerDateTimePlus45Sec { get; set; }
    }
}