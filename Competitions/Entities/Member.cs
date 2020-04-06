using System;

namespace Competitions.Entities
{
    public struct MemberPrimaryKey
    {
        public long ID { get; set; }
    }
    public class Member
    {
        public MemberPrimaryKey PrimaryKey { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
