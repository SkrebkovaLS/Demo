using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class PaymentList
    {
        public int IdPaymentList { get; set; }
        public int? EmployeeId { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime DateOfIssue { get; set; }

    }
}
