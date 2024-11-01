namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class BankAccountNumber : IEquatable<BankAccountNumber>
    {
        private readonly string _accountNumber;

        private BankAccountNumber() { } // For EF Core
        public BankAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException("Bank account number cannot be null or empty.", nameof(accountNumber));
            }

            if (!IsValidAccountNumber(accountNumber))
            {
                throw new ArgumentException("Invalid bank account number format.", nameof(accountNumber));
            }

            _accountNumber = accountNumber;
        }

        public string AccountNumber => _accountNumber;

        private bool IsValidAccountNumber(string accountNumber)
        {
            
            return accountNumber.Length >= 10 && accountNumber.Length <= 12 &&
                   long.TryParse(accountNumber, out _);
        }

        public override string ToString() => _accountNumber;

        public override bool Equals(object obj)
        {
            return Equals(obj as BankAccountNumber);
        }

        public bool Equals(BankAccountNumber other)
        {
            return other != null && _accountNumber.Equals(other._accountNumber, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return _accountNumber.GetHashCode();
        }

        public static bool operator ==(BankAccountNumber left, BankAccountNumber right)
        {
            return EqualityComparer<BankAccountNumber>.Default.Equals(left, right);
        }

        public static bool operator !=(BankAccountNumber left, BankAccountNumber right)
        {
            return !(left == right);
        }
    }
}
