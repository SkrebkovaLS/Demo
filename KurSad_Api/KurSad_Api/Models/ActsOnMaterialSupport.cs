using System;
using System.Collections.Generic;

#nullable disable

namespace KurSad_Api.Models
{
    public partial class ActsOnMaterialSupport
    {
        public int IdActsOnMaterialSupport { get; set; }
        public int NumberActs { get; set; }
        public int? UserId { get; set; }
    }
}
