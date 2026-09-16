using FINOVA.Database;
using FINOVA.DataModel.Common;
using FINOVA.DataModel.Shared;

namespace FINOVA.Repository.Shared
{
    public class CommonRepository : BaseRepository
    {
        private readonly IFINOVADatabase _database = null;
        public CommonRepository()
        {
            _database = new FINOVADatabase();
        }
        public async Task<SimpleResponse> APIRequestRecord_Log(ApiRequestLog request)
        {

            string outputstr = "";
            SimpleResponse response = new SimpleResponse();
            var dbCommand = _database.GetStoredProcCommand("usp_insertApiLog");
            _database.AddInParameter(dbCommand, "@apiname", request.apiname);
            _database.AddInParameter(dbCommand, "@plainrequest ", request.plainrequest);
            _database.AddInParameter(dbCommand, "@plainresponse", request.plainresponse);
            _database.AddInParameter(dbCommand, "@encryptedrequest", request.encryptedrequest);
            _database.AddInParameter(dbCommand, "@encryptedresponse", request.encryptedresponse);

            await _database.ExecuteNonQueryAsync(dbCommand);


            response.Result = outputstr;
            return response;

        }
    }
}
