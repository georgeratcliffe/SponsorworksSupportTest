using System;
using System.ComponentModel.DataAnnotations;

namespace SupportEngineerTest.Web.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        [StringLength(50)]
        public string Status { get; set; }
        
        [StringLength(50)]
        public string Priority { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
