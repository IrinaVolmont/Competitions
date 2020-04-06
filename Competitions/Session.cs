using System;
using System.Data.SQLite;
using Competitions.Clients;

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
}
