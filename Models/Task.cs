using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minimalAPIef.Models
{
    public class Task
    {
        [Key]
        public Guid TaskId {get;set;}
        
        
        [ForeignKey("CategoryId")]
        public Guid CategoryId {get;set;}
        
        
        [Required]
        [MaxLength(200)]
        public string Title {get;set;}

        public string Desciption {get;set;}

        public Priority PriorityTask{get;set;}
        
        public DateTime CreationDate {get;set;}

        public virtual Category Category {get;set;}

        [NotMapped]
        public string Summary {get;set;}


    }
    public enum Priority
    {
        low,
        Half,
        High,
    }
}