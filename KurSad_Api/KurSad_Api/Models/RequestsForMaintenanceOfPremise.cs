using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class RequestsForMaintenanceOfPremise
    {
        public int IdRequestsForMaintenanceOfPremises { get; set; }
        public int? UserId { get; set; }
        public int Room { get; set; }
        public int NumberRequests { get; set; }
        public DateTime DateRequests { get; set; }

    }
}
