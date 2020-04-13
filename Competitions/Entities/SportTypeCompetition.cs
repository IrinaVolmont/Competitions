namespace Competitions.Entities
{
    public class SportTypeCompetition : EntityBase
    {
        public Competition Competition { get; set; }
        public SportTypeDiscipline SportTypeDiscipline { get; set; }
    }
}
