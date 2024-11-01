namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Number { get; }

        private PhoneNumber() { }
        public PhoneNumber(string phoneNumber)
        {
            // Validation logic for phone number format
            if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException("Phone number is required");
            if (!phoneNumber.StartsWith("+")) throw new ArgumentException("Phone number must start with +");
            if (phoneNumber.Length != 11) throw new ArgumentException("Phone number lenth is invalid");
            Number = phoneNumber;
        }
    }
}
