using System.ComponentModel;
using System.Linq;

namespace Competitions.Entities
{
    public abstract class EntityBase
    {
        /// <summary>
        /// ID получается из базы или назначается из автоинкремента
        /// </summary>
        [Browsable(false)]
        public long? ID { get; set; }

        public override int GetHashCode()
        {
            return ID.HasValue ? (int)ID : 0;
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

        public string GetPropertiesInfo()
        {
            var properties = this.GetType().GetProperties();
            return string.Join(" ; ",
                properties.Select(x => $"[{x.Name}]={x.GetValue(this)}"));
        }
    }
}
