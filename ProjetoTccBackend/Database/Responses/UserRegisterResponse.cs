using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Responses
{
    public class UserRegisterResponse
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("userName")]
        public string UserName;

        [JsonPropertyName("email")]
        public string Email;

        [JsonPropertyName("emailConfirmed")]
        public bool EmailConfirmed;

        [JsonPropertyName("joinYear")]
        public int JoinYear;

        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber;

        [JsonPropertyName("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed;
    }
}
