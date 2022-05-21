using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class ListCase
    {
        public ListCase()
        {
        }

        public int IdCases { get; set; }
        public int? TypeId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfRequestCases { get; set; }

    }
}
