//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MezoExperts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Questions = new HashSet<Question>();
        }
    
        public int Id { get; set; }
        public string CategoryName { get; set; }
    
        public virtual ICollection<Question> Questions { get; set; }
    }
}
