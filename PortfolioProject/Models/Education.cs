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

    public partial class Education
    {
        public int EducationId { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olmal�d�r.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olmal�d�r.")]
        public string EducationDate { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(250, ErrorMessage = "En fazla 250 karakter olmal�d�r.")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(500, ErrorMessage = "En fazla 500 karakter olmal�d�r.")]
        public string Description { get; set; }
    }
}
