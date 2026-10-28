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
        /// <summary>
        /// Creates a new transaction and returns the generated TransactionCode.
        /// </summary>
        public async Task<string> CreateNewTransaction(
            NewTransactionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            string transactionCode = string.Empty;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[usp_NewTransaction]");

            // ============================================================
            // INPUT PARAMETERS
            // ============================================================

            _database.AddInParameter(
                dbCommand,
                "@OrganizationId",
                request.OrganizationId);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                request.ServiceId);

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

            _database.AddInParameter(
                dbCommand,
                "@TxnType",
                request.TxnType);

            _database.AddInParameter(
                dbCommand,
                "@Amount",
                request.Amount);

            _database.AddInParameter(
                dbCommand,
                "@TxnFee",
                request.TxnFee);

            // CreatedBy should always come from authenticated user
            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@TxnPlateform",
                request.TxnPlateform);


            // ============================================================
            // OUTPUT PARAMETER
            // ============================================================

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                100);


            // ============================================================
            // EXECUTE
            // ============================================================

            await _database.ExecuteNonQueryAsync(
                dbCommand);


            // ============================================================
            // GET GENERATED TRANSACTION CODE
            // ============================================================

            transactionCode =
                Convert.ToString(
                    dbCommand.Parameters["@Out_ID"].Value)
                ?? string.Empty;

            return transactionCode;
        }

        // ============================================================
        // UPDATE TRANSACTION STATUS
        // ============================================================
        public async Task<UpdateTransactionStatusResponse?> UpdateTransactionStatus(
            UpdateTransactionStatusRequest request,
            IFINOVAServiceUser serviceUser)
        {
            UpdateTransactionStatusResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[usp_updatetransactionstatus]");

            // ========================================================
            // INPUT PARAMETERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@TransactionId",
                request.TransactionId);

            _database.AddInParameter(
                dbCommand,
                "@RelatedReference",
                request.RelatedReference);

            _database.AddInParameter(
                dbCommand,
                "@RefNo1",
                request.RefNo1);

            _database.AddInParameter(
                dbCommand,
                "@RefNo2",
                request.RefNo2);

            _database.AddInParameter(
                dbCommand,
                "@RefNo3",
                request.RefNo3);

            _database.AddInParameter(
                dbCommand,
                "@RefNo4",
                request.RefNo4);

            _database.AddInParameter(
                dbCommand,
                "@RefNo5",
                request.RefNo5);

            _database.AddInParameter(
                dbCommand,
                "@RefNo6",
                request.RefNo6);

            _database.AddInParameter(
                dbCommand,
                "@RefNo7",
                request.RefNo7);

            _database.AddInParameter(
                dbCommand,
                "@RefNo8",
                request.RefNo8);

            _database.AddInParameter(
                dbCommand,
                "@RefNo9",
                request.RefNo9);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            // UpdatedBy comes from authenticated user
            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);


            // ========================================================
            // EXECUTE AND READ RESULT
            // ========================================================

            using (var dataReader =
                await _database.ExecuteReaderAsync(dbCommand))
            {
                if (await dataReader.ReadAsync())
                {
                    response = new UpdateTransactionStatusResponse
                    {
                        TransactionId =
                            GetInt64Value(
                                dataReader,
                                "TransactionId").Value,

                        RelatedReference =
                            GetStringValue(
                                dataReader,
                                "RelatedReference"),

                        RefNo1 =
                            GetStringValue(
                                dataReader,
                                "RefNo1"),

                        RefNo2 =
                            GetStringValue(
                                dataReader,
                                "RefNo2"),

                        RefNo3 =
                            GetStringValue(
                                dataReader,
                                "RefNo3"),

                        RefNo4 =
                            GetStringValue(
                                dataReader,
                                "RefNo4"),

                        RefNo5 =
                            GetStringValue(
                                dataReader,
                                "RefNo5"),

                        RefNo6 =
                            GetStringValue(
                                dataReader,
                                "RefNo6"),

                        RefNo7 =
                            GetStringValue(
                                dataReader,
                                "RefNo7"),

                        RefNo8 =
                            GetStringValue(
                                dataReader,
                                "RefNo8"),

                        RefNo9 =
                            GetStringValue(
                                dataReader,
                                "RefNo9"),

                        Status =GetInt32Value(dataReader,"Status").Value,

                        UpdatedOn =
                            GetDateTimeValue(
                                dataReader,
                                "UpdatedOn"),

                        UpdatedBy =
                            GetInt64Value(
                                dataReader,
                                "UpdatedBy")
                    };
                }
            }

            return response;
        }
    }
}
