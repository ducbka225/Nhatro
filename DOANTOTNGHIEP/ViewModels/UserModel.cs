using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public double? Balance { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public int? Admin { get; set; }
    }
}