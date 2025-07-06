using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Database.Responses.Competition;
using ProjetoTccBackend.Exceptions.Judge;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Services
{
    public class GroupAttemptService : IGroupAttemptService
    {
        private readonly IJudgeService _judgeService;

        public GroupAttemptService(IJudgeService judgeService)
        {
            this._judgeService = judgeService;
        }

        /// <inheritdoc/>
        public async Task<ExerciseSubmissionResponse> SubmitExerciseAttempt(GroupExerciseAttemptRequest request)
        {
            throw new NotImplementedException();

            try
            {
                await this._judgeService.SendGroupExerciseAttempt(request);

                return new ExerciseSubmissionResponse()
                {
                    ExerciseId = request.ExerciseId
                };
            }
            catch (ExerciseNotFoundException ex)
            {

            }
            catch (JudgeSubmissionException ex)
            {

            }
            catch (JudgePresentationException ex)
            {

            }
            catch (JudgeWrongAnswerException ex)
            {

            }
            catch (JudgeCompilationException ex)
            {

            }
            catch (JudgeTimeLimitException ex)
            {

            }
            catch (JudgeMemoryLimitException ex)
            {

            }
            catch (JudgeRuntimeException ex)
            {

            }
            catch (JudgeSecurityException ex)
            {

            }
        }


    }
}
