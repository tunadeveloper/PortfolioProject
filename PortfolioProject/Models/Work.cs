//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortfolioProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Work
    {
        public int WorkId { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olmal�d�r.")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olmal�d�r.")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olmal�d�r.")]
        public string GithubUrl { get; set; }
    }
}