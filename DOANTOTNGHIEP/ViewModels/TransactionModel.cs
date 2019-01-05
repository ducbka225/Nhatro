using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANTOTNGHIEP.ViewModels
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? TotalPrice { get; set; }
    }
}