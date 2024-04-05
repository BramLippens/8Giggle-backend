using Domain.Common;
using Domain.Posts;

namespace Domain.Users;

public class User: Entity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public Address Address { get; set; }
    public List<Post> Posts { get; set; } = new List<Post>();

    public User() { }

    public User(string firstname, string lastname, string username, string email, string role, Address address)
    {
        Firstname = firstname;
        Lastname = lastname;
        Username = username;
        Email = email;
        Role = role;
        Address = address;
    }
}
