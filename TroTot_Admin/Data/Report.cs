using System;
using System.Collections.Generic;

namespace TroTot_Admin.Data
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public int? TotalPost { get; set; }
        public int? ReportUser { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
