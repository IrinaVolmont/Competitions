using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using Competitions.Clients;
using Competitions.Entities;
using Competitions.UI;

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
        public readonly AccessRightsClient AccessRights;

        public IClientBase<EntityBase> GetClient<T>() where T : EntityBase => GetClient(typeof(T));
        public IClientBase<EntityBase> GetClient(Type type)
        {
            if (type == typeof(Member))
                return Members;
            if (type == typeof(Role))
                return Roles;
            if (type == typeof(Employee))
                return Employees;
            if (type == typeof(UnitType))
                return UnitTypes;
            if (type == typeof(Discipline))
                return Disciplines;
            if (type == typeof(SportType))
                return SportTypes;
            if (type == typeof(SportTypeDiscipline))
                return SportTypesDisciplines;
            if (type == typeof(Competition))
                return Competitions;
            if (type == typeof(CompetitionResult))
                return CompetitionsResults;
            if (type == typeof(SportTypeCompetition))
                return SportTypesCompetitions;
            if (type == typeof(ConductCompetition))
                return ConductsCompetitions;
            if (type == typeof(AccessRight))
                return AccessRights;

            return null;
        }

        private Employee _currentEmployee;

        public Employee CurrentEmployee
        {
            get { return _currentEmployee?.ID == null ? null : Employees.GetItem(_currentEmployee.ID.Value, true); }
            private set { _currentEmployee = value; }
        }

        public bool Authorize(string login, string password)
        {
            var cryptedPassword = MD5Ext.GetMd5Hash(password);
            try
            {
                CurrentEmployee = Employees.GetAll(true).FirstOrDefault(x => x.Login.Equals(login));
            }
            catch { } //авторизация не удалась, достаточно вернуть false

            if (string.IsNullOrEmpty(CurrentEmployee.CryptedPassword))
            {
                var currentEmployee = CurrentEmployee;
                currentEmployee.CryptedPassword = cryptedPassword;
                this.Employees.Edit(currentEmployee, true);
                CurrentEmployee = currentEmployee;
            }

            if (CurrentEmployee.CryptedPassword != cryptedPassword)
            {
                CurrentEmployee = null;
            }

            return CurrentEmployee != null;
        }

        public void DeAuthorize()
        {
            CurrentEmployee = null;
        }

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
            AccessRights = new AccessRightsClient(this);
        }
        public void Dispose()
        {
            Connection.Close();
        }
    }

    public class EntitiesConverter : ExpandableObjectConverter
    {
        private Session _session = MainForm.Session;

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var client = _session.GetClient(context.PropertyDescriptor.PropertyType);
            if (client != null)
            {
                var allEntities = client.GetAll();
                return new StandardValuesCollection(allEntities);
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
            if (value is EntityBase entityBase)
            {
                return entityBase.ToString();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value)
        {
            if (context?.PropertyDescriptor?.PropertyType != null)
            {
                var client = _session.GetClient(context?.PropertyDescriptor?.PropertyType);
                if (client != null)
                {
                    var allEntities = client.GetAll();
                    var foundObj = allEntities.FirstOrDefault(x => x.ToString().Equals(value?.ToString()));
                    if (foundObj != null)
                    {
                        return foundObj;
                    }
                }
            }
                return base.ConvertFrom(context, culture, value);
        }
    }
}
