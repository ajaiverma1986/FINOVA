using FINOVA.Database;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Report;
using FINOVA.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.Repository
{
   public class ReportRepository:BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public ReportRepository()
        {
            _database = new FINOVADatabase();
        }
        // ============================================================
        // TRANSACTION DETAILS REPORT
        // FILTER + PAGING + SORTING
        // ============================================================
        public async Task<TransactionReportResponse> GetTransactionDetailsReport(
            TransactionReportRequest request,
            IFINOVAServiceUser serviceUser)
        {
            TransactionReportResponse response =
                new TransactionReportResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[RPT].[usp_TransactionDetailsReport]");

            // ========================================================
            // FILTERS
            // ========================================================

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
                "@UserName",
                request.UserName);

            _database.AddInParameter(
                dbCommand,
                "@TransactionId",
                request.TransactionId);

            _database.AddInParameter(
                dbCommand,
                "@TransactionCode",
                request.TransactionCode);

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
                "@PartnerTxnId",
                request.PartnerTxnId);

            _database.AddInParameter(
                dbCommand,
                "@PartnerRetailorId",
                request.PartnerRetailorId);

            _database.AddInParameter(
                dbCommand,
                "@RefNo",
                request.RefNo);

            _database.AddInParameter(
                dbCommand,
                "@TxnType",
                request.TxnType);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@TxnPlateform",
                request.TxnPlateform);

            _database.AddInParameter(
                dbCommand,
                "@MinAmount",
                request.MinAmount);

            _database.AddInParameter(
                dbCommand,
                "@MaxAmount",
                request.MaxAmount);

            _database.AddInParameter(
                dbCommand,
                "@FromDate",
                request.FromDate);

            _database.AddInParameter(
                dbCommand,
                "@ToDate",
                request.ToDate);


            // ========================================================
            // PAGING
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@PageNumber",
                request.PageNumber);

            _database.AddInParameter(
                dbCommand,
                "@PageSize",
                request.PageSize);


            // ========================================================
            // SORTING
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@SortColumn",
                request.SortColumn);

            _database.AddInParameter(
                dbCommand,
                "@SortDirection",
                request.SortDirection);


            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                // ====================================================
                // RESULT SET 1
                // TRANSACTION RECORDS
                // ====================================================

                while (dataReader.Read())
                {
                    response.Records.Add(
                        MapTransactionReport(dataReader));
                }


                // ====================================================
                // RESULT SET 2
                // PAGING
                // ====================================================

                if (dataReader.NextResult() &&
                    dataReader.Read())
                {
                    response.Paging.TotalRecords =
                        GetInt64Value(
                            dataReader,
                            "TotalRecords").Value;

                    response.Paging.TotalPages =
                        GetInt32Value(
                            dataReader,
                            "TotalPages").Value;

                    response.Paging.PageNumber =
                        GetInt32Value(
                            dataReader,
                            "PageNumber").Value;

                    response.Paging.PageSize =
                        GetInt32Value(
                            dataReader,
                            "PageSize").Value;

                    response.Paging.HasNextPage =
                        Convert.ToBoolean(
                            dataReader["HasNextPage"]);

                    response.Paging.HasPreviousPage =
                        Convert.ToBoolean(
                            dataReader["HasPreviousPage"]);
                }
            }

            return response;
        }
        private TransactionReportRow MapTransactionReport(
    System.Data.IDataReader dataReader)
        {
            TransactionReportRow row =
                new TransactionReportRow();

            row.TransactionId =
                GetInt64Value(dataReader, "TransactionId").Value;

            row.TransactionCode =
                GetStringValue(dataReader, "TransactionCode");

            row.OrganizationId =
                GetInt64Value(dataReader, "OrganizationId");

            row.UserMasterId =
                GetInt64Value(dataReader, "UserMasterId");

            row.UserName =
                GetStringValue(dataReader, "UserName");

            row.DisplayName =
                GetStringValue(dataReader, "DisplayName");

            row.FirstName =
                GetStringValue(dataReader, "FirstName");

            row.LastName =
                GetStringValue(dataReader, "LastName");


            // Service

            row.ServiceId =
                GetInt32Value(dataReader, "ServiceId");

            row.ServiceCode =
                GetStringValue(dataReader, "ServiceCode");

            row.ServiceName =
                GetStringValue(dataReader, "ServiceName");


            // Agency

            row.AgencyId =
                GetInt32Value(dataReader, "AgencyId");

            row.AgencyCode =
                GetStringValue(dataReader, "AgencyCode");

            row.AgencyName =
                GetStringValue(dataReader, "AgencyName");


            // Partner / Reference

            row.PartnerTxnId =
                GetStringValue(dataReader, "PartnerTxnId");

            row.PartnerRetailorId =
                GetStringValue(dataReader, "PartnerRetailorId");

            row.RefNo =
                GetStringValue(dataReader, "RefNo");

            row.RelatedReference =
                GetStringValue(dataReader, "RelatedReference");

            row.Description =
                GetStringValue(dataReader, "Description");

            row.BankTxnDatetime =
                GetStringValue(dataReader, "BankTxnDatetime");

            row.TxnType =
                GetStringValue(dataReader, "TxnType");


            // Amount

            row.Amount =
                dataReader["Amount"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dataReader["Amount"]);

            row.TxnFee =
                dataReader["TxnFee"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dataReader["TxnFee"]);

            row.MarginComm =
                dataReader["MarginComm"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dataReader["MarginComm"]);


            // Status

            row.FailureReason =
                GetStringValue(dataReader, "FailureReason");

            row.Status =
                GetInt32Value(dataReader, "Status").Value;

            row.StatusName =
                GetStringValue(dataReader, "StatusName");

            row.TxnPlateform =
                GetStringValue(dataReader, "TxnPlateform");


            // Created

            row.CreatedOn =
                GetDateTimeValue(dataReader, "CreatedOn");

            row.CreatedBy =
                GetInt64Value(dataReader, "CreatedBy").Value;

            row.CreatedByName =
                GetStringValue(dataReader, "CreatedByName");


            // Updated

            row.UpdatedOn =
                GetDateTimeValue(dataReader, "UpdatedOn");

            row.UpdatedBy =
                GetInt64Value(dataReader, "UpdatedBy");

            row.UpdatedByName =
                GetStringValue(dataReader, "UpdatedByName");


            // Cancellation

            row.CanceledDate =
                GetDateTimeValue(dataReader, "CanceledDate");

            row.CanceledBy =
                GetInt64Value(dataReader, "CanceledBy");

            row.CancelReason =
                GetStringValue(dataReader, "CancelReason");

            return row;
        }
        // ============================================================
        // GET USER DASHBOARD
        // ============================================================
        public async Task<UserDashboardResponse> GetUserDashboard(
            long userMasterId,
            DateTime? reportDate,
            IFINOVAServiceUser serviceUser)
        {
            UserDashboardResponse response =
                new UserDashboardResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[RPT].[usp_UserDashboard]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                userMasterId);

            _database.AddInParameter(
                dbCommand,
                "@ReportDate",
                reportDate);


            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                // ====================================================
                // RESULT SET 1
                // SUMMARY CARDS
                // ====================================================

                if (dataReader.Read())
                {
                    response.Summary.ReportDate =
                        GetDateTimeValue(
                            dataReader,
                            "ReportDate").Value;

                    response.Summary.TotalTransactions =
                        GetInt64Value(
                            dataReader,
                            "TotalTransactions").Value;

                    response.Summary.TransactionAmount =
                        GetDecimalValue(
                            dataReader,
                            "TransactionAmount");

                    response.Summary.TotalCommissionEarned =
                        GetDecimalValue(
                            dataReader,
                            "TotalCommissionEarned");

                    response.Summary.TotalTransactionFee =
                        GetDecimalValue(
                            dataReader,
                            "TotalTransactionFee");

                    response.Summary.AverageTransactionAmount =
                        GetDecimalValue(
                            dataReader,
                            "AverageTransactionAmount");
                }


                // ====================================================
                // RESULT SET 2
                // 7-DAY LINE CHART
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardTrend row =
                            new DashboardTrend();

                        row.ReportDate =
                            GetDateTimeValue(
                                dataReader,
                                "ReportDate").Value;

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        row.CommissionAmount =
                            GetDecimalValue(
                                dataReader,
                                "CommissionAmount");

                        response.TransactionTrend.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 3
                // TOP 10 TRANSACTIONS
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardTopTransaction row =
                            new DashboardTopTransaction();

                        row.TransactionId =
                            GetInt64Value(
                                dataReader,
                                "TransactionId").Value;

                        row.TransactionCode =
                            GetStringValue(
                                dataReader,
                                "TransactionCode");

                        row.UserMasterId =
                            GetInt64Value(
                                dataReader,
                                "UserMasterId");

                        row.UserName =
                            GetStringValue(
                                dataReader,
                                "UserName");

                        row.ServiceId =
                            GetInt32Value(
                                dataReader,
                                "ServiceId");

                        row.ServiceName =
                            GetStringValue(
                                dataReader,
                                "ServiceName");

                        row.AgencyId =
                            GetInt32Value(
                                dataReader,
                                "AgencyId");

                        row.AgencyName =
                            GetStringValue(
                                dataReader,
                                "AgencyName");

                        row.PartnerTxnId =
                            GetStringValue(
                                dataReader,
                                "PartnerTxnId");

                        row.TxnType =
                            GetStringValue(
                                dataReader,
                                "TxnType");

                        row.Amount =
                            GetDecimalValue(
                                dataReader,
                                "Amount");

                        row.TxnFee =
                            GetDecimalValue(
                                dataReader,
                                "TxnFee");

                        row.MarginComm =
                            GetDecimalValue(
                                dataReader,
                                "MarginComm");

                        row.Status =
                            GetInt32Value(
                                dataReader,
                                "Status").Value;

                        row.StatusName =
                            GetStringValue(
                                dataReader,
                                "StatusName");

                        row.TxnPlateform =
                            GetStringValue(
                                dataReader,
                                "TxnPlateform");

                        row.CreatedOn =
                            GetDateTimeValue(
                                dataReader,
                                "CreatedOn").Value;

                        response.TopTransactions.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 4
                // DAYBOOK
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardDaybook row =
                            new DashboardDaybook();

                        row.ServiceId =
                            GetInt32Value(
                                dataReader,
                                "ServiceId");

                        row.ServiceCode =
                            GetStringValue(
                                dataReader,
                                "ServiceCode");

                        row.ServiceName =
                            GetStringValue(
                                dataReader,
                                "ServiceName");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        row.TransactionFee =
                            GetDecimalValue(
                                dataReader,
                                "TransactionFee");

                        row.CommissionAmount =
                            GetDecimalValue(
                                dataReader,
                                "CommissionAmount");

                        row.TotalDebitAmount =
                            GetDecimalValue(
                                dataReader,
                                "TotalDebitAmount");

                        response.Daybook.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 5
                // STATUS DISTRIBUTION - PIE CHART
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardStatusDistribution row =
                            new DashboardStatusDistribution();

                        row.Status =
                            GetInt32Value(
                                dataReader,
                                "Status").Value;

                        row.StatusName =
                            GetStringValue(
                                dataReader,
                                "StatusName");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        response.StatusDistribution.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 6
                // SERVICE PERFORMANCE - BAR CHART
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardServicePerformance row =
                            new DashboardServicePerformance();

                        row.ServiceId =
                            GetInt32Value(
                                dataReader,
                                "ServiceId");

                        row.ServiceName =
                            GetStringValue(
                                dataReader,
                                "ServiceName");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        row.CommissionAmount =
                            GetDecimalValue(
                                dataReader,
                                "CommissionAmount");

                        response.ServicePerformance.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 7
                // PLATFORM DISTRIBUTION
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardPlatformDistribution row =
                            new DashboardPlatformDistribution();

                        row.TxnPlateform =
                            GetStringValue(
                                dataReader,
                                "TxnPlateform");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount");

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        response.PlatformDistribution.Add(row);
                    }
                }
            }

            return response;
        }
        // ============================================================
        // GET USER DASHBOARD
        // ============================================================
        public async Task<UserDashboardResponse> GetAdminDashboard(
            long? userMasterId,
            DateTime? reportDate,
            IFINOVAServiceUser serviceUser)
        {
            UserDashboardResponse response =
                new UserDashboardResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[RPT].[usp_UserDashboard]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                userMasterId);

            _database.AddInParameter(
                dbCommand,
                "@ReportDate",
                reportDate);


            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                // ====================================================
                // RESULT SET 1
                // SUMMARY CARDS
                // ====================================================

                if (dataReader.Read())
                {
                    response.Summary.ReportDate =
                        GetDateTimeValue(
                            dataReader,
                            "ReportDate").Value;

                    response.Summary.TotalTransactions =
                        GetInt64Value(
                            dataReader,
                            "TotalTransactions").Value;

                    response.Summary.TransactionAmount =
                        GetDecimalValue(
                            dataReader,
                            "TransactionAmount");

                    response.Summary.TotalCommissionEarned =
                        GetDecimalValue(
                            dataReader,
                            "TotalCommissionEarned");

                    response.Summary.TotalTransactionFee =
                        GetDecimalValue(
                            dataReader,
                            "TotalTransactionFee");

                    response.Summary.AverageTransactionAmount =
                        GetDecimalValue(
                            dataReader,
                            "AverageTransactionAmount");
                }


                // ====================================================
                // RESULT SET 2
                // 7-DAY LINE CHART
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardTrend row =
                            new DashboardTrend();

                        row.ReportDate =
                            GetDateTimeValue(
                                dataReader,
                                "ReportDate").Value;

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        row.CommissionAmount =
                            GetDecimalValue(
                                dataReader,
                                "CommissionAmount");

                        response.TransactionTrend.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 3
                // TOP 10 TRANSACTIONS
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardTopTransaction row =
                            new DashboardTopTransaction();

                        row.TransactionId =
                            GetInt64Value(
                                dataReader,
                                "TransactionId").Value;

                        row.TransactionCode =
                            GetStringValue(
                                dataReader,
                                "TransactionCode");

                        row.UserMasterId =
                            GetInt64Value(
                                dataReader,
                                "UserMasterId");

                        row.UserName =
                            GetStringValue(
                                dataReader,
                                "UserName");

                        row.ServiceId =
                            GetInt32Value(
                                dataReader,
                                "ServiceId");

                        row.ServiceName =
                            GetStringValue(
                                dataReader,
                                "ServiceName");

                        row.AgencyId =
                            GetInt32Value(
                                dataReader,
                                "AgencyId");

                        row.AgencyName =
                            GetStringValue(
                                dataReader,
                                "AgencyName");

                        row.PartnerTxnId =
                            GetStringValue(
                                dataReader,
                                "PartnerTxnId");

                        row.TxnType =
                            GetStringValue(
                                dataReader,
                                "TxnType");

                        row.Amount =
                            GetDecimalValue(
                                dataReader,
                                "Amount");

                        row.TxnFee =
                            GetDecimalValue(
                                dataReader,
                                "TxnFee");

                        row.MarginComm =
                            GetDecimalValue(
                                dataReader,
                                "MarginComm");

                        row.Status =
                            GetInt32Value(
                                dataReader,
                                "Status").Value;

                        row.StatusName =
                            GetStringValue(
                                dataReader,
                                "StatusName");

                        row.TxnPlateform =
                            GetStringValue(
                                dataReader,
                                "TxnPlateform");

                        row.CreatedOn =
                            GetDateTimeValue(
                                dataReader,
                                "CreatedOn").Value;

                        response.TopTransactions.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 4
                // DAYBOOK
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardDaybook row =
                            new DashboardDaybook();

                        row.ServiceId =
                            GetInt32Value(
                                dataReader,
                                "ServiceId");

                        row.ServiceCode =
                            GetStringValue(
                                dataReader,
                                "ServiceCode");

                        row.ServiceName =
                            GetStringValue(
                                dataReader,
                                "ServiceName");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        row.TransactionFee =
                            GetDecimalValue(
                                dataReader,
                                "TransactionFee");

                        row.CommissionAmount =
                            GetDecimalValue(
                                dataReader,
                                "CommissionAmount");

                        row.TotalDebitAmount =
                            GetDecimalValue(
                                dataReader,
                                "TotalDebitAmount");

                        response.Daybook.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 5
                // STATUS DISTRIBUTION - PIE CHART
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardStatusDistribution row =
                            new DashboardStatusDistribution();

                        row.Status =
                            GetInt32Value(
                                dataReader,
                                "Status").Value;

                        row.StatusName =
                            GetStringValue(
                                dataReader,
                                "StatusName");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        response.StatusDistribution.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 6
                // SERVICE PERFORMANCE - BAR CHART
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardServicePerformance row =
                            new DashboardServicePerformance();

                        row.ServiceId =
                            GetInt32Value(
                                dataReader,
                                "ServiceId");

                        row.ServiceName =
                            GetStringValue(
                                dataReader,
                                "ServiceName");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount").Value;

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        row.CommissionAmount =
                            GetDecimalValue(
                                dataReader,
                                "CommissionAmount");

                        response.ServicePerformance.Add(row);
                    }
                }


                // ====================================================
                // RESULT SET 7
                // PLATFORM DISTRIBUTION
                // ====================================================

                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DashboardPlatformDistribution row =
                            new DashboardPlatformDistribution();

                        row.TxnPlateform =
                            GetStringValue(
                                dataReader,
                                "TxnPlateform");

                        row.TransactionCount =
                            GetInt64Value(
                                dataReader,
                                "TransactionCount");

                        row.TransactionAmount =
                            GetDecimalValue(
                                dataReader,
                                "TransactionAmount");

                        response.PlatformDistribution.Add(row);
                    }
                }
            }

            return response;
        }
        // ============================================================
        // USER DETAILS REPORT
        // FILTER + PAGING + SORTING
        // ============================================================
        public async Task<UserDetailsReportResponse> GetUserDetailsReport(
            UserDetailsReportRequest request,
            IFINOVAServiceUser serviceUser)
        {
            UserDetailsReportResponse response =
                new UserDetailsReportResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[RPT].[usp_UserDetailsReport]");


            // ========================================================
            // USER FILTERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@ParentId",
                request.ParentId);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationId",
                request.OrganizationId);

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                request.UserTypeId);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

            _database.AddInParameter(
                dbCommand,
                "@Name",
                request.Name);

            _database.AddInParameter(
                dbCommand,
                "@EmailId",
                request.EmailId);

            _database.AddInParameter(
                dbCommand,
                "@MobileNo",
                request.MobileNo);

            _database.AddInParameter(
                dbCommand,
                "@GenderId",
                request.GenderId);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@IsLocked",
                request.IsLocked);

            _database.AddInParameter(
                dbCommand,
                "@IsPasswordExpired",
                request.IsPasswordExpired);


            // ========================================================
            // OTHER DETAIL FILTERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@PANCard",
                request.PANCard);

            _database.AddInParameter(
                dbCommand,
                "@AadharCard",
                request.AadharCard);

            _database.AddInParameter(
                dbCommand,
                "@GSTNo",
                request.GSTNo);


            // ========================================================
            // CONFIGURATION FILTER
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);


            // ========================================================
            // BALANCE FILTERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@MinAvailableLimit",
                request.MinAvailableLimit);

            _database.AddInParameter(
                dbCommand,
                "@MaxAvailableLimit",
                request.MaxAvailableLimit);


            // ========================================================
            // DATE FILTERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@FromDate",
                request.FromDate);

            _database.AddInParameter(
                dbCommand,
                "@ToDate",
                request.ToDate);


            // ========================================================
            // KYC / BANK / ADDRESS FILTERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@HasKYC",
                request.HasKYC);

            _database.AddInParameter(
                dbCommand,
                "@HasBankAccount",
                request.HasBankAccount);

            _database.AddInParameter(
                dbCommand,
                "@HasAddress",
                request.HasAddress);


            // ========================================================
            // PAGING
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@PageNumber",
                request.PageNumber);

            _database.AddInParameter(
                dbCommand,
                "@PageSize",
                request.PageSize);


            // ========================================================
            // SORTING
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@SortColumn",
                request.SortColumn);

            _database.AddInParameter(
                dbCommand,
                "@SortDirection",
                request.SortDirection);


            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                // ====================================================
                // RESULT SET 1
                // USER RECORDS
                // ====================================================

                while (dataReader.Read())
                {
                    response.Records.Add(
                        MapUserDetailsReport(dataReader));
                }


                // ====================================================
                // RESULT SET 2
                // PAGING INFORMATION
                // ====================================================

                if (dataReader.NextResult() &&
                    dataReader.Read())
                {
                    response.Paging.TotalRecords =
                        GetInt64Value(
                            dataReader,
                            "TotalRecords").Value;

                    response.Paging.TotalPages =
                        GetInt32Value(
                            dataReader,
                            "TotalPages").Value;

                    response.Paging.PageNumber =
                        GetInt32Value(
                            dataReader,
                            "PageNumber").Value;

                    response.Paging.PageSize =
                        GetInt32Value(
                            dataReader,
                            "PageSize").Value;

                    response.Paging.HasNextPage =
                        Convert.ToBoolean(
                            dataReader["HasNextPage"]);

                    response.Paging.HasPreviousPage =
                        Convert.ToBoolean(
                            dataReader["HasPreviousPage"]);
                }
            }

            return response;
        }
        private UserDetailsReportRow MapUserDetailsReport(
    System.Data.IDataReader dataReader)
        {
            UserDetailsReportRow row =
                new UserDetailsReportRow();


            // ========================================================
            // USER MASTER
            // ========================================================

            row.UserMasterID =
                GetInt64Value(
                    dataReader,
                    "UserMasterID").Value;

            row.ParentId =
                GetInt64Value(
                    dataReader,
                    "ParentId");

            row.ParentUserName =
                GetStringValue(
                    dataReader,
                    "ParentUserName");

            row.ParentDisplayName =
                GetStringValue(
                    dataReader,
                    "ParentDisplayName");

            row.UserTypeId =
                GetInt32Value(
                    dataReader,
                    "UserTypeId");

            row.OrganizationID =
                GetInt32Value(
                    dataReader,
                    "OrganizationID").Value;

            row.DomainUserName =
                GetStringValue(
                    dataReader,
                    "DomainUserName");

            row.UserName =
                GetStringValue(
                    dataReader,
                    "UserName");

            row.Title =
                GetStringValue(
                    dataReader,
                    "Title");

            row.FirstName =
                GetStringValue(
                    dataReader,
                    "FirstName");

            row.MiddleName =
                GetStringValue(
                    dataReader,
                    "MiddleName");

            row.LastName =
                GetStringValue(
                    dataReader,
                    "LastName");

            row.DisplayName =
                GetStringValue(
                    dataReader,
                    "DisplayName");


            // ========================================================
            // GENDER
            // ========================================================

            row.GenderID =
                dataReader["GenderID"] == DBNull.Value
                    ? (byte)0
                    : Convert.ToByte(
                        dataReader["GenderID"]);


            // ========================================================
            // CONTACT
            // ========================================================

            row.EmailId =
                GetStringValue(
                    dataReader,
                    "EmailId");

            row.MobileNo =
                GetStringValue(
                    dataReader,
                    "MobileNo");


            // ========================================================
            // ACCOUNT SECURITY
            // ========================================================

            row.IsPasswordExpired =
                dataReader["IsPasswordExpired"] != DBNull.Value
                &&
                Convert.ToBoolean(
                    dataReader["IsPasswordExpired"]);

            row.IsLocked =
                dataReader["IsLocked"] != DBNull.Value
                &&
                Convert.ToBoolean(
                    dataReader["IsLocked"]);

            row.LockedTill =
                GetNullableDateTimeOffset(
                    dataReader,
                    "LockedTill");


            // ========================================================
            // USER ID / STATUS
            // ========================================================

            row.UserId =
                GetInt64Value(
                    dataReader,
                    "UserId").Value;

            row.UserRemarkReason =
                GetStringValue(
                    dataReader,
                    "UserRemarkReason");

            row.Status =
                dataReader["Status"] == DBNull.Value
                    ? (byte)0
                    : Convert.ToByte(
                        dataReader["Status"]);

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");


            // ========================================================
            // USER DETAILS / BALANCE
            // ========================================================

            row.UserDetailId =
                GetInt64Value(
                    dataReader,
                    "UserDetailId");

            row.AvailableLimit =
                GetDecimalReportValue(
                    dataReader,
                    "AvailableLimit");

            row.ThresoldLimit =
                GetDecimalReportValue(
                    dataReader,
                    "ThresoldLimit");

            row.UserDetailStatus =
                GetInt32Value(
                    dataReader,
                    "UserDetailStatus");

            row.UserDetailRemarkReason =
                GetStringValue(
                    dataReader,
                    "UserDetailRemarkReason");


            // ========================================================
            // USER CONFIGURATION
            // ========================================================

            row.ConfigurationId =
                GetInt64Value(
                    dataReader,
                    "ConfigurationId");

            row.MinTxn =
                GetDecimalReportValue(
                    dataReader,
                    "MinTxn");

            row.MaxTxn =
                GetDecimalReportValue(
                    dataReader,
                    "MaxTxn");

            row.ChargeTypeOn =
                GetInt32Value(
                    dataReader,
                    "ChargeTypeOn");

            row.PlanId =
                GetInt32Value(
                    dataReader,
                    "PlanId");

            row.MaxPayinAmount =
                GetDecimalReportValue(
                    dataReader,
                    "MaxPayinAmount");

            row.MaxNoofcountPayin =
                GetInt32Value(
                    dataReader,
                    "MaxNoofcountPayin");

            row.SameAmountPayinAllowed =
                GetInt32Value(
                    dataReader,
                    "SameAmountPayinAllowed");


            // ========================================================
            // OTHER DETAILS
            // ========================================================

            row.OtherDetailId =
                GetInt64Value(
                    dataReader,
                    "OtherDetailId");

            row.Pancard =
                GetStringValue(
                    dataReader,
                    "Pancard");

            row.AadharCard =
                GetStringValue(
                    dataReader,
                    "AadharCard");

            row.GSTNo =
                GetStringValue(
                    dataReader,
                    "GSTNo");

            row.OtherDetailStatus =
                GetInt32Value(
                    dataReader,
                    "OtherDetailStatus");


            // ========================================================
            // KYC SUMMARY
            // ========================================================

            row.KYCCount =
                GetInt64Value(
                    dataReader,
                    "KYCCount").Value;

            row.ActiveKYCCount =
                GetInt64Value(
                    dataReader,
                    "ActiveKYCCount").Value;

            row.HasKYC =
                dataReader["HasKYC"] != DBNull.Value
                &&
                Convert.ToBoolean(
                    dataReader["HasKYC"]);


            // ========================================================
            // BANK ACCOUNT SUMMARY
            // ========================================================

            row.BankAccountCount =
                GetInt64Value(
                    dataReader,
                    "BankAccountCount").Value;

            row.ActiveBankAccountCount =
                GetInt64Value(
                    dataReader,
                    "ActiveBankAccountCount").Value;

            row.HasBankAccount =
                dataReader["HasBankAccount"] != DBNull.Value
                &&
                Convert.ToBoolean(
                    dataReader["HasBankAccount"]);


            // ========================================================
            // ADDRESS SUMMARY
            // ========================================================

            row.AddressCount =
                GetInt64Value(
                    dataReader,
                    "AddressCount").Value;

            row.ActiveAddressCount =
                GetInt64Value(
                    dataReader,
                    "ActiveAddressCount").Value;

            row.HasAddress =
                dataReader["HasAddress"] != DBNull.Value
                &&
                Convert.ToBoolean(
                    dataReader["HasAddress"]);


            // ========================================================
            // AUDIT
            // ========================================================

            row.CreatedOn =
                GetDateTimeOffsetValue(
                    dataReader,
                    "CreatedOn").Value;

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.CreatedByName =
                GetStringValue(
                    dataReader,
                    "CreatedByName");

            row.UpdatedOn =
                GetNullableDateTimeOffset(
                    dataReader,
                    "UpdatedOn");

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            row.UpdatedByName =
                GetStringValue(
                    dataReader,
                    "UpdatedByName");

            return row;
        }
    }
}
