using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Transactions
{
    public class NewTransactionRequest
    {
        public long OrganizationId { get; set; }
        public long UserMasterId { get; set; }

        public int ServiceId { get; set; }
        public int AgencyId { get; set; }

        public string PartnerTxnId { get; set; }
        public string PartnerRetailorId { get; set; }

        public string Description { get; set; }
        public string TxnType { get; set; }

        public decimal Amount { get; set; }
        public decimal TxnFee { get; set; }
        public decimal Margin { get; set; }

        public string TxnPlateform { get; set; }
    }
}
