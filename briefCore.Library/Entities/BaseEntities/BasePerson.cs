namespace briefCore.Library.Entities.BaseEntities
{
    using System;

    public class BasePerson : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
        public DateTime? DoD { get; set; }
        public string Bio { get; set; }
    }
}