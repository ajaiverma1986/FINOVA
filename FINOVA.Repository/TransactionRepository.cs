using FINOVA.Database;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Transactions;
using FINOVA.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.Repository
{
    public class TransactionRepository : BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public TransactionRepository()
        {
            _database = new FINOVADatabase();
        }
        // ============================================================
        // CREATE NEW TRANSACTION
        // ============================================================
        public async Task<string> CreateNewTransaction(
            NewTransactionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            string transactionCode = string.Empty;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[usp_NewTransaction]");

            // ========================================================
            // INPUT PARAMETERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@organizationId",
                request.OrganizationId);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@serviceid",
                request.ServiceId);

            _database.AddInParameter(
                dbCommand,
                "@agencyid",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@partnertxnid",
                request.PartnerTxnId);

            _database.AddInParameter(
                dbCommand,
                "@partnerretailorid",
                request.PartnerRetailorId);

            _database.AddInParameter(
                dbCommand,
                "@description",
                request.Description);

            _database.AddInParameter(
                dbCommand,
                "@txntype",
                request.TxnType);

            _database.AddInParameter(
                dbCommand,
                "@Amount",
                request.Amount);

            _database.AddInParameter(
                dbCommand,
                "@Txnfee",
                request.TxnFee);

            _database.AddInParameter(
                dbCommand,
                "@Margin",
                request.Margin);

            // CreatedBy should come from authenticated user
            _database.AddInParameter(
                dbCommand,
                "@createdby",
                serviceUser.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@txnplateform",
                request.TxnPlateform);


            // ========================================================
            // OUTPUT PARAMETER
            // TransactionCode VARCHAR(100)
            // ========================================================

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                100);


            // ========================================================
            // EXECUTE
            // ========================================================

            await _database.ExecuteNonQueryAsync(
                dbCommand);


            // ========================================================
            // GET TRANSACTION CODE
            // ========================================================

            transactionCode =
                Convert.ToString(
                    dbCommand.Parameters["@Out_ID"].Value)
                ?? string.Empty;

            return transactionCode;
        }
    }
}
