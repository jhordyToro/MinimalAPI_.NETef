using System.ComponentModel.DataAnnotations; // This code line is for import the DataAnnotations of entityFramework for can expesifiqued better our table of data                                                      
using System.ComponentModel.DataAnnotations.Schema; // This line of code is to be able to make relations of type ForeignKey and others 
using System.Text.Json.Serialization;

namespace minimalAPIef.Models
{
    public class Task
    {
        // [Key]
        public Guid TaskId {get;set;}
        
        
        // [ForeignKey("CategoryId")]
        public Guid CategoryId {get;set;}
        
        
        // [Required]
        // [MaxLength(200)]
        public string Title {get;set;}

        public string? Description {get;set;}

        public Priority PriorityTask{get;set;}
        
        public DateTime CreationDate {get;set;}

        public virtual Category Category {get;set;}

        // [NotMapped]
        public string Summary {get;set;}


    }
    public enum Priority
    {
        low,
        Half,
        High,
    }
}