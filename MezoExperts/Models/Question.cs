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
    
    public partial class Question
    {
        public Question()
        {
            this.QuestionFiles = new HashSet<QuestionFile>();
        }
    
        public int Id { get; set; }
        public int PostedBy { get; set; }
        public string Details { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<QuestionFile> QuestionFiles { get; set; }
        public virtual Category Category { get; set; }
    }
}
