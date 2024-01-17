namespace Domain.Models.Person
{
    public class PersonModel
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; } = string.Empty;
        public virtual string LastName { get; set; } = string.Empty;
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Address { get; set; } = string.Empty;
        public virtual string PhoneNumber { get; set; } = string.Empty;
        public virtual string Email { get; set; } = string.Empty;
    }
}
