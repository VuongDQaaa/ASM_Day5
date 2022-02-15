using ASM_Day5.Data;
using ASM_Day5.Models;

namespace ASM_Day5.Services
{
    public class MemberService : IMemberservice
    {
        public List<Member> GetAllMember()
        {
            return MemberData.Members;
        }
        public List<Member> GetFullName()
        {
            return MemberData.Members;
        }
        public List<Member> GetMaleMember()
        {
            return MemberData.Members.Where(m => m.Gender == Enum.Gender.Male).ToList();
        }
        public Tuple<List<Member>, List<Member>, List<Member>> GetMemberByYear(int year)
        {
            var lessThan2000 = MemberData.Members.Where(x => x.DateOfBirth.Year < year).ToList();
            var greaterThan2000 = MemberData.Members.Where(x => x.DateOfBirth.Year > year).ToList();
            var equalThan2000 = MemberData.Members.Where(x => x.DateOfBirth.Year == year).ToList();
            return Tuple.Create(lessThan2000, greaterThan2000, equalThan2000);
        }
        public Member OldestMember()
        {
            return MemberData.Members.MinBy(m => m.DateOfBirth.Year);
        }
    }
}