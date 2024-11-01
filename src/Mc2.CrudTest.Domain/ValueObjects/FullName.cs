using System.Net;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public partial class FullName : IEquatable<FullName>
    {
        public string FirstName { get; }
        public string LastName { get; }
        private FullName() { } // For EF Core
        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is required");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name is required");
            if (!LetterCheck().IsMatch(firstName) || !LetterCheck().IsMatch(lastName))
                throw new ArgumentException("first name or last name is not valid");
            FirstName = firstName;
            LastName = lastName;
        }

        [GeneratedRegex(@"^[a-zA-Z]+$")]
        private static partial Regex LetterCheck();

        public override bool Equals(object obj)
        {
            return Equals(obj as FullName);
        }

        public bool Equals(FullName other)
        {
            return other != null &&
                FirstName.Equals(other.FirstName, StringComparison.Ordinal) &&
                LastName.Equals(other.LastName, StringComparison.Ordinal);
        }
    }
}
