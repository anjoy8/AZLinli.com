﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZLinli.Com.Blog.Model.Models
{
    public class User
    {
        public int uID { get; set; }

        public string uLoginName { get; set; }

        public string uLoginPWD { get; set; }

        public string uRealName { get; set; }

        public int uStatus { get; set; }

        public string uRemark { get; set; }

        public System.DateTime uCreateTime { get; set; }

        public System.DateTime uUpdateTime { get; set; }
    }
}
