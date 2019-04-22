﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectModel.CustomObject
{
    public class CustomMail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }


        public string[] From { get; set; }
        public string[] To { get; set; }
        public string[] CC { get; set; }
    }
}
