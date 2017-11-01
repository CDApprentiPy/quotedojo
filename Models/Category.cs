using System.Collections.Generic;

namespace newqd.Models
{
    public class Category : BaseEntity
    {
        public int categoryId {get; set;}
        public string category {get; set;}
        public List<QuoteCat> quotecats {get; set;}

        public Category()
        {
            quotecats = new List<QuoteCat>();
        }
    }
}