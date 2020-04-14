using System.ComponentModel;

namespace Competitions.Entities
{
    public class Employee : EntityBase
    {
        public string Login { get; set; }

        [Browsable(false)]
        public string CryptedPassword { get; set; }

        public string FullName { get; set; }

        [TypeConverter(typeof(EnumerableConverter))]
        public Role Role { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
