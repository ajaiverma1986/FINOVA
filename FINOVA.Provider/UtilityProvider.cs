using FINOVA.Commonlib.Security;
using FINOVA.DataModel.Entities.SysModel;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;
using System.Security.Cryptography;
using System.Text;

namespace FINOVA.Provider
{
    public class UtilityProvider : BaseProvider
    {
        public readonly SysMgrRepository _repository = null;
        public UtilityProvider()
        {
            _repository = new SysMgrRepository();
        }
        public async Task<OTPResponse> SendOTP(OTPRequest otpRequest)
        {
            string smscontent = "";
            OTPResponse response = new OTPResponse();

            if (otpRequest != null && !string.IsNullOrEmpty(otpRequest.mobileno))
            {
                string _otp = CommonHelper.RandomDigits(6);
                smscontent = "" + _otp + " is the reference no. for FIA Verification. Do Not share the reference no. with anyone other than the agent assisting.";

                response = await _repository.SendOTP(otpRequest.mobileno, _otp);

            }
            return response;
        }

        public async Task<SimpleResponse> ValidateOTP(OTPValidateRequest fIAOTPValidateRequest)
        {
            SimpleResponse response = new SimpleResponse();

            if (fIAOTPValidateRequest != null && !string.IsNullOrEmpty(fIAOTPValidateRequest.mobileno) && !string.IsNullOrEmpty(fIAOTPValidateRequest.otp))
            {
                response = await _repository.ValidateOTP(fIAOTPValidateRequest.mobileno, fIAOTPValidateRequest.otp);

            }
            return response;
        }

        public string GetHMACSHA256(string text, string key)
        {
            UTF8Encoding encoder = new UTF8Encoding();

            byte[] hashValue;
            byte[] keybyt = encoder.GetBytes(key);
            byte[] message = encoder.GetBytes(text);

            HMACSHA256 hashString = new HMACSHA256(keybyt);
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
      
    }
}
