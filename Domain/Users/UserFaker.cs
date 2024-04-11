using Bogus;
using Domain.Common;

namespace Domain.Users;

public class UserFaker: Faker<User>
{
    public UserFaker()
    {
        RuleFor(x => x.Id, x => x.IndexFaker + 1);
        RuleFor(x => x.Firstname, x => x.Person.FirstName);
        RuleFor(x => x.Lastname, x => x.Person.LastName);
        RuleFor(x => x.Username, x => x.Person.UserName);
        RuleFor(x => x.Email, x => x.Person.Email);
        RuleFor(x => x.Role, x => "User");
        RuleFor(x => x.Address, x => new AddressFaker().Generate(1).First());
    }
}
