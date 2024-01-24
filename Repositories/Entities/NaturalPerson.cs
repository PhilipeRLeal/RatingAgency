

using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class NaturalPerson : BaseEntity
    {
        [ForeignKey("Person")]
        public int Person_Id { get; set; }

        public Person Person { get; set; }

        public PersonType Type { get; set; } = PersonType.Natural;
        

        public DateTime DateOfBirth { get; set; }


        public bool CheckIfTodayIsBirthday()
        {
            var condition  = (DateOfBirth.Month == DateTime.Today.Month) && (DateOfBirth.Day == DateTime.Today.Day);

            return condition;
        }

        public int Age()
        {
            // Calculate the age.
            var age = DateTime.Today.Year - DateOfBirth.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) {
                age--;
             };

            if (DateTime.Today.Month < DateOfBirth.Date.Month) { 
                age--;
            }

            else if (DateTime.Today.Month == DateOfBirth.Date.Month)
            {
                if (DateTime.Today.Day < DateOfBirth.Date.Day)
                { 
                    age--;
                }
            }

            return age;
        }
    }
}
