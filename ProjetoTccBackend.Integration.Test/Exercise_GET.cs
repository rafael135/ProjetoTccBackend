using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProjetoTccBackend.Database;
using ProjetoTccBackend.Database.Responses.Exercise;
using ProjetoTccBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ProjetoTccBackend.Integration.Test
{
    public class Exercise_GET : IClassFixture<TCCWebApplicationFactory>, IAsyncLifetime
    {
        private readonly TCCWebApplicationFactory _factory;
        private readonly ITestOutputHelper _output;
        private HttpClient _httpClient;

        private Exercise _exerciseCreated;

        public Exercise_GET(TCCWebApplicationFactory factory, ITestOutputHelper output)
        {
            this._factory = factory;
            this._output = output;
            this._httpClient = this._factory.CreateClient();
        }

        public async Task DisposeAsync()
        {

        }

        public async Task InitializeAsync()
        {
            this._exerciseCreated = new Exercise()
            {
                Title = "Title Test",
                Description = "Test",
                EstimatedTime = TimeSpan.FromMinutes(20),
                JudgeUuid = new Guid().ToString()
            };

            using (TccDbContext dbContext = this._factory.GetDbContext())
            {
                dbContext.Set<Exercise>().Add(this._exerciseCreated);
                dbContext.SaveChanges();
            }

            
        }

        [Fact]
        public async Task GetExerciseById_Returns_OkStatus()
        {
            // Arrange
            HttpStatusCode expectedStatus = HttpStatusCode.OK;
            
            // Act
            HttpResponseMessage response = await this._httpClient.GetAsync($"/api/exercise/{this._exerciseCreated.Id}");
            this._output.WriteLine(await response.Content.ReadAsStringAsync());
            ExerciseResponse? exerciseResponse = await response.Content.ReadFromJsonAsync<ExerciseResponse>();


            // Assert
            Assert.NotNull(exerciseResponse);
            Assert.Equal(expectedStatus, response.StatusCode);
            Assert.Equal(this._exerciseCreated.Id, exerciseResponse.Id);
            Assert.Equal(this._exerciseCreated.Title, exerciseResponse.Title);
            Assert.Equal(this._exerciseCreated.Description, exerciseResponse.Description);
        }


        [Fact]
        public async Task GetExerciseById_Returns_NotFoundStatus()
        {
            // Arrange
            HttpStatusCode expectedStatus = HttpStatusCode.NotFound;

            // Act
            HttpResponseMessage response = await this._httpClient.GetAsync($"/api/exercise/{8273}");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(expectedStatus, response.StatusCode);
        }
    }
}
