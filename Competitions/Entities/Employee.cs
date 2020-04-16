using System.ComponentModel;

namespace Competitions.Entities
{
    public class Employee : EntityBase
    {
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Browsable(false)]
        public string CryptedPassword { get; set; }

        [DisplayName("ФИО")]
        public string FullName { get; set; }

        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Должность")]
        public Role Role { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
