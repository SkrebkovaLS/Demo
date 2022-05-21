using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class ListOfOtherDocument
    {
        public ListOfOtherDocument()
        {
        }

        public int IdDocuments { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }

    }
}
