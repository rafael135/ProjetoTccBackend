using Bogus;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Integration.Test.DataBuilders
{
    class UserDataBuilder : Faker<User>
    {
        public string RA { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int JoinYear { get; set; }

        public UserDataBuilder()
        {
            CustomInstantiator(u =>
            {
                Random random = new Random();

                string ra = $"${random.NextInt64(100000, 9999999)}";

                string firstName = u.Person.FirstName;
                string lastName = u.Person.LastName;
                string userName = $"{firstName} {lastName}";

                string email = u.Internet.Email(firstName, lastName);
                int joinYear = ((int)random.NextInt64(2020, 2025));

                return new User()
                {
                    RA = ra,
                    UserName = userName,
                    Email = email,
                    JoinYear = joinYear
                };
            });
        }

        public User Build() => Generate();

    }
}
