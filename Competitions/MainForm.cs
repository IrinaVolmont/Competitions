using System;
using System.Windows.Forms;
using Competitions.Entities;

namespace Competitions
{
    public partial class MainForm : Form
    {
        private readonly Session _session;
        public MainForm()
        {
            InitializeComponent();

            _session = new Session(Properties.Settings.Default.SqlConnection);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var competitions = _session.Competitions.GetAll();
            var competitionsResults = _session.CompetitionsResults.GetAll();
            var conductsCompetitions = _session.ConductsCompetitions.GetAll();
            var disciplines = _session.Disciplines.GetAll();
            var employees = _session.Employees.GetAll();
            var members = _session.Members.GetAll();
            var roles = _session.Roles.GetAll();
            var sportTypes = _session.SportTypes.GetAll();
            var sportTypesCompetitions = _session.SportTypesCompetitions.GetAll();
            var sportTypesDisciplines = _session.SportTypesDisciplines.GetAll();
            var unitTypes = _session.UnitTypes.GetAll();
        }
    }
}
