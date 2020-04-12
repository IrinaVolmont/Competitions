using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Competitions.Entities
{
    public struct EmployeePrimaryKey
    {
        public string Login { get; set; }
    }

    public class Employee
    {
        public EmployeePrimaryKey PrimaryKey;

        [DisplayName("Логин")]
        public string Login
        {
            get { return PrimaryKey.Login; }
            set { PrimaryKey.Login = value; }
        }

        [DisplayName("ФИО")]
        public string FullName { get; set; }

        [TypeConverter(typeof(EnumerableConverter))]
        [DisplayName("Должность")]
        public Role Role { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
