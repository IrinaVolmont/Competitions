using System;

namespace Competitions.Entities
{
    public class Member : EntityBase
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return FullName;
        }

        
    }
}
