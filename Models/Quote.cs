using System;
using System.Collections.Generic;

namespace newqd.Models
{
    public class Quote : BaseEntity
    {
        public int quoteId {get; set;}
        public string message {get; set;}

        public int authorId {get; set;}
        public Author author {get; set;}
        public int metaId {get; set;}
        public Meta meta {get; set;}
        public List<QuoteCat> quotecats {get; set;}

        public Quote()
        {
            quotecats = new List<QuoteCat>();
        }

    }
}