using System;
using System.ComponentModel.DataAnnotations;

namespace SupportEngineerTest.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
