using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Database.Responses.Competition;
using ProjetoTccBackend.Enums.Judge;
using ProjetoTccBackend.Exceptions.Judge;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Services
{
    public class GroupAttemptService : IGroupAttemptService
    {
        private readonly IJudgeService _judgeService;
        private readonly IUserService _userService;

        public GroupAttemptService(IJudgeService judgeService, IUserService userService)
        {
            this._judgeService = judgeService;
            this._userService = userService;
        }

        /// <inheritdoc/>
        public async Task<ExerciseSubmissionResponse> SubmitExerciseAttempt(GroupExerciseAttemptRequest request)
        {
            var loggedUser = this._userService.GetHttpContextLoggerUser();

            if(loggedUser is null || loggedUser.GroupId is null)
            {
                throw new UnauthorizedAccessException("Usuário não possui permissão para essa ação");
            }


            try
            {
                var response = await this._judgeService.SendGroupExerciseAttempt(request);

                return new ExerciseSubmissionResponse()
                {
                    ExerciseId = request.ExerciseId,
                    Accepted = response.Equals(JudgeSubmissionResponse.Accepted),
                    JudgeResponse = response,
                    GroupId = loggedUser.GroupId.Value,
                };
            }
            catch (Exception ex)
            {
                throw new JudgeException(ex.Message, ex.Data);
            }
        }


    }
}
