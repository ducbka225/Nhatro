using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.ViewModels
{
    public class AddUserModel
    {
        public int userid { get; set; }
        public string txtUser { get; set; }
        public string txtEmail { get; set; }
        public string txtPass { get; set; }
        public int? level { get; set; }
    }
}