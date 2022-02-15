using ASM_Day5.Models;
namespace ASM_Day5.Services
{
    public interface IMemberservice
    {
        List<Member> GetMaleMember();
        Member OldestMember();
        Tuple<List<Member>, List<Member>, List<Member>> GetMemberByYear(int year);
        List<Member> GetAllMember();
        List<Member> GetFullName();
    }
}