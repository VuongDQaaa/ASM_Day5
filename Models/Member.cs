using ASM_Day5.Enum;
namespace ASM_Day5.Models
{
    public class Member
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public Gender Gender {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string PhoneNum {get; set;}
        public string BirthPlace {get; set;}
        public bool IsGraduated {get; set;}
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName );
            }
        }
    }
}