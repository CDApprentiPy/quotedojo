using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace newqd.Models
{
    public class QuoteCat : BaseEntity
    {
        [Key]
        public int quotecategoryId {get; set;}
        public int quoteId {get; set;}
        public Quote quote {get; set;}
        public int categoryId {get; set;}
        public Category category {get; set;}
    }
}