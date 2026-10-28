using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Transactions
{
    public class UpdateTransactionStatusResponse
    {
        public long TransactionId { get; set; }

        public string? RelatedReference { get; set; }

        public string? RefNo1 { get; set; }
        public string? RefNo2 { get; set; }
        public string? RefNo3 { get; set; }
        public string? RefNo4 { get; set; }
        public string? RefNo5 { get; set; }
        public string? RefNo6 { get; set; }
        public string? RefNo7 { get; set; }
        public string? RefNo8 { get; set; }
        public string? RefNo9 { get; set; }

        public int Status { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }

}
