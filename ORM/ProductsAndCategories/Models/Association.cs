using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {get; set;}
        public Category Category {get; set;}
        public int CategoryId {get; set;}
        public Product Product {get; set;}
        public int ProductId {get; set;}

        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;

    }
}