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

    public partial class SocialMedia
    {
        public int SocialMediaId { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olmal�d�r.")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olmal�d�r.")]
        public string Icon { get; set; }

        public Nullable<bool> Status { get; set; }


        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olmal�d�r.")]
        public string SocialMediaUrl { get; set; }
    }
}
