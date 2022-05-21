using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class ApplicationsForTechnicalSupport
    {
        public int IdApplicationsForTechnicalSupport { get; set; }
        public DateTime DateAppication { get; set; }
        public string Description { get; set; }
        public int NumberApplication { get; set; }
        public int? UserId { get; set; }

    }
}
