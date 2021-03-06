//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOANTOTNGHIEP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Image1 = new HashSet<Image>();
            this.ProductDetails = new HashSet<ProductDetails>();
            this.Transaction = new HashSet<Transaction>();
            this.Transaction1 = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<double> Acreage { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> IsLevel { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> IdProductType { get; set; }
        public Nullable<int> IdNeedFor { get; set; }
        public Nullable<int> IdStreet { get; set; }
        public Nullable<int> IdLocation { get; set; }
        public string Owner { get; set; }
        public Nullable<int> Phone { get; set; }
        public string Image { get; set; }
    
        public virtual ICollection<Image> Image1 { get; set; }
        public virtual Location Location { get; set; }
        public virtual NeedFor NeedFor { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual Street Street { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
        public virtual ICollection<Transaction> Transaction1 { get; set; }
    }
}
