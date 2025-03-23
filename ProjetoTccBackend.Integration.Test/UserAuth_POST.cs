using ProjetoTccBackend.Database.Requests.Auth;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace ProjetoTccBackend.Integration.Test
{
    public class UserAuth_POST : IClassFixture<TCCWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public UserAuth_POST(TCCWebApplicationFactory factory, ITestOutputHelper output)
        {
            _client = factory.CreateClient();
            this._output = output;
        }

        
        [Theory]
        [InlineData("113937", "teste3", "teste3@gmail.com", "00000000", 2021, HttpStatusCode.OK)]
        [InlineData("113826", "teste4", "teste4@gmail.com", "00000000", 2021, HttpStatusCode.OK)]
        [InlineData("182763", "teste5", "teste5", "00000000", 2020, HttpStatusCode.BadRequest)]
        public async Task Register_User(string ra, string userName, string email, string password, int joinYear, HttpStatusCode expectedStatus)
        {
            // Arrange
            RegisterUserRequest user = new RegisterUserRequest()
            {
                RA = ra,
                UserName = userName,
                Email = email,
                JoinYear = joinYear,
                Password = password
            };

            // Act
            var response = await this._client.PostAsJsonAsync<RegisterUserRequest>("/api/auth/register", user);


            // Assert
            Assert.NotNull(response);
            string c = await response.Content.ReadAsStringAsync();
            this._output.WriteLine(c);
            Assert.Equal(expectedStatus, response.StatusCode);
            
        }


        [Theory]
        [InlineData("teste@gmail.com", "00000000", HttpStatusCode.OK)]
        public async Task Login_User(string email, string password, HttpStatusCode expectedStatus)
        {
            // Arrange
            LoginUserRequest user = new LoginUserRequest()
            {
                Email = email,
                Password = password
            };
            

            // Act
            var response = await this._client.PostAsJsonAsync<LoginUserRequest>("/api/auth/login", user);


            // Assert
            Assert.NotNull(response);
            Assert.Equal(expectedStatus, response.StatusCode);
        }
    }
}