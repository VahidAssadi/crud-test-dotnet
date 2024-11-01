using PhoneNumbers;

namespace Mc2.CrudTest.Application.Features.Validations
{
    public interface IPhoneNumberValidator
    {
        bool IsValidPhoneNumber(string number, string regionCode);
    }
    public class PhoneNumberValidator : IPhoneNumberValidator
    {
        private readonly PhoneNumberUtil _phoneNumberUtil;

        public PhoneNumberValidator()
        {
            _phoneNumberUtil = PhoneNumberUtil.GetInstance();
        }

        public bool IsValidPhoneNumber(string number, string regionCode)
        {
            try
            {
                var phoneNumber = _phoneNumberUtil.Parse(number, regionCode);
                return _phoneNumberUtil.IsValidNumber(phoneNumber);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
