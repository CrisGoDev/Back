using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class PeopleInfo
    {
        public int? UniqueId { get; set; }
        public string DrugName { get; set; }
        public string Condition { get; set; }
        public int? Rating { get; set; }
    }
}
