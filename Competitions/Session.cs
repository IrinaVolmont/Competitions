using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using Competitions.Clients;
using Competitions.Entities;

namespace Competitions
{
    public class Session : IDisposable
    {
        public readonly SQLiteConnection Connection;

        public readonly MembersClient Members;
        public readonly RolesClient Roles;
        public readonly EmployeesClient Employees;
        public readonly UnitTypesClient UnitTypes;
        public readonly DisciplinesClient Disciplines;
        public readonly SportTypesClient SportTypes;
        public readonly SportTypesDisciplinesClient SportTypesDisciplines;
        public readonly CompetitionsClient Competitions;
        public readonly CompetitionsResultsClient CompetitionsResults;
        public readonly SportTypesCompetitionsClient SportTypesCompetitions;
        public readonly ConductsCompetitionsClient ConductsCompetitions;

        public Session(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();

            Members = new MembersClient(this);
            Roles = new RolesClient(this);
            Employees = new EmployeesClient(this);
            UnitTypes = new UnitTypesClient(this);
            Disciplines = new DisciplinesClient(this);
            SportTypes = new SportTypesClient(this);
            SportTypesDisciplines = new SportTypesDisciplinesClient(this);
            Competitions = new CompetitionsClient(this);
            CompetitionsResults = new CompetitionsResultsClient(this);
            SportTypesCompetitions = new SportTypesCompetitionsClient(this);
            ConductsCompetitions = new ConductsCompetitionsClient(this);
        }
        public void Dispose()
        {
            Connection.Close();
        }
    }

    public class EnumerableConverter : ExpandableObjectConverter
    {
        private Session _session = MainForm.Session;

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var contextType = context.Instance.GetType();

            if (contextType == typeof(Employee))
            {
                var allRoles = _session.Roles.GetAll();
                return new StandardValuesCollection(allRoles);
            }

            return null;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            if (value is Role role)
            {
                return role.PrimaryKey.Name;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value)
        {
            if (context?.PropertyDescriptor?.PropertyType == typeof(Role))
            {
                return _session.Roles.GetAll().First(x => x.PrimaryKey.Name.Equals(value.ToString()));
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
