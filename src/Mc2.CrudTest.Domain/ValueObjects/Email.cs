using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class Email : IEquatable<Email>
    {
        private static readonly Regex EmailRegex =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public string Address { get; }

        private Email() { }
        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Email address cannot be null or empty.", nameof(address));
            }

            if (!IsValidEmail(address))
            {
                throw new ArgumentException("Invalid email address format.", nameof(address));
            }

            Address = address;
        }

        public static bool IsValidEmail(string email)
        {
            return EmailRegex.IsMatch(email);
        }

        public override string ToString() => Address;

        public override bool Equals(object obj)
        {
            return Equals(obj as Email);
        }

        public bool Equals(Email other)
        {
            return other != null && Address.Equals(other.Address, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Address.ToLowerInvariant().GetHashCode();
        }

        public static bool operator ==(Email left, Email right)
        {
            return EqualityComparer<Email>.Default.Equals(left, right);
        }

        public static bool operator !=(Email left, Email right)
        {
            return !(left == right);
        }
    }
}
