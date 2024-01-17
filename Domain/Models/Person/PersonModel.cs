namespace Domain.Models.Person
{
    public class PersonModel
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; } = string.Empty;
        public virtual string LastName { get; set; } = string.Empty;
        public virtual DateOnly DateOfBirth { get; set; }
        public virtual string Adress { get; set; } = string.Empty;
        public virtual string PhoneNumber { get; set; } = string.Empty;
        public virtual string Email { get; set; } = string.Empty;
    }
}
