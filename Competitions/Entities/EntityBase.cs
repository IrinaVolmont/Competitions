namespace Competitions.Entities
{
    public abstract class EntityBase
    {
        public long ID { get; set; }

        public override int GetHashCode()
        {
            return (int)ID;
        }

        public override bool Equals(object obj)
        {
            bool isEquals = false;
            if (obj is EntityBase entityBase)
            {
                isEquals = entityBase.ID == this.ID;
            }

            return isEquals;
        }
    }
}
