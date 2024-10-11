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

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Message = new HashSet<Message>();
        }
    
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bu alan bo� ge�ilemez.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olmal�d�r.")]
        public string CatagoryName { get; set; }
        public Nullable<bool> CategoryStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message { get; set; }
        public object CategoryName { get; internal set; }
    }
}
