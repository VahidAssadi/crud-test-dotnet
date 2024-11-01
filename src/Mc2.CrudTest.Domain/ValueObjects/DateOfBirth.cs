namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class DateOfBirth: IEquatable<DateOfBirth>
    {
        private readonly DateTime _BirthDate;

        public DateOfBirth(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(date));
            }

            _BirthDate = date;
        }
        private DateOfBirth()
        {

        }
        public DateTime BirthDate => _BirthDate;

        public override string ToString() => _BirthDate.ToString("yyyy-MM-dd");

        public override bool Equals(object obj)
        {
            return Equals(obj as DateOfBirth);
        }

        public bool Equals(DateOfBirth other)
        {
            return other != null && _BirthDate.Equals(other._BirthDate);
        }

        public override int GetHashCode()
        {
            return _BirthDate.GetHashCode();
        }

        // Equality operators
        public static bool operator ==(DateOfBirth left, DateOfBirth right)
        {
            return EqualityComparer<DateOfBirth>.Default.Equals(left, right);
        }

        public static bool operator !=(DateOfBirth left, DateOfBirth right)
        {
            return !(left == right);
        }
    }
}
