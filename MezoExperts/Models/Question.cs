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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    
    public partial class Question
    {
        public Question()
        {
            this.QuestionFiles = new HashSet<QuestionFile>();
            this.Replies = new HashSet<Reply>();
        }

        //[Required]
        public int Id { get; set; }

        [Required]
        public Nullable<int> PostedBy { get; set; }

        [AllowHtml]
        public string Details { get; set; }

        [Required(ErrorMessage = "Please select category.")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter your question's title.")]
        [StringLength(30, ErrorMessage = "Your question's title must be between 10 and 30 characters.", MinimumLength = 10)]
        public string Title { get; set; }

        public Nullable<System.DateTime> Time { get; set; }
        public string Status { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<QuestionFile> QuestionFiles { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
