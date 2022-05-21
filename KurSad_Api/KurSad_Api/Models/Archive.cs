using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class Archive
    {
        public int IdRecord { get; set; }
        public int? CasesId { get; set; }
        public int? DocumentsId { get; set; }
        public DateTime DateOfDeposit { get; set; }
        public DateTime DateOfRequest { get; set; }
    }
}
