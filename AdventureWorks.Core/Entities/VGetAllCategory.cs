using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Core.Entities
{
    public partial class VGetAllCategory
    {
        public string ParentProductCategoryName { get; set; }
        public string ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
