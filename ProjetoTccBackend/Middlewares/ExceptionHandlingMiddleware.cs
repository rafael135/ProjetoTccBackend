﻿using ProjetoTccBackend.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace ProjetoTccBackend.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
            //this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            bool isFormException = false;

            var response = new object();

            try
            {
                await _next(context);
            }
            catch (ErrorException ex) // Erro genérico lançado manualmente no código
            {
                response = new { message = ex.Message };
            }
            catch (FormException ex) // Erro de validação lançado manualmente
            {
                isFormException = true;
                response = new
                {
                    errors = ex.FormData.Select(x =>
                    {
                        return new { field = x.Key, error = x.Value };
                    })
                };
            }
            catch (Exception ex)
            {
                //this._logger.LogError(ex, "Erro insperado");

                // Caso seja erro de ModelState inválido
                if(context.Request.HasFormContentType || IsJsonRequest(context))
                {
                    isFormException = true;
                    response = HandleValidationException(ex);
                }
                else // Caso seja um erro não esperado
                {
                    response = new
                    {
                        errors = new[]
                        {
                            new { field = "general", error = "Ocorreu um erro inesperado. Tente novamente mais tarde." }
                        }
                    };
                }
            }

            context.Response.ContentType = "application/json";
            if(isFormException is true)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            } else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private bool IsJsonRequest(HttpContext context)
        {
            if (context.Request.ContentType is null) return false;

            return context.Response.ContentType!.Contains("application/json", StringComparison.OrdinalIgnoreCase);
        }

        private object HandleValidationException(Exception ex)
        {
            var errors = new List<object>();

            if(ex is ValidationException validationEx) // Validação manual foi lançadas
            {
                errors.AddRange(validationEx.ValidationResult.MemberNames.Select(field => new
                {
                    field,
                    error = validationEx.ValidationResult.ErrorMessage
                }));
            }
            else if(ex is ArgumentException argEx) // Erro específico
            {
                errors.Add(new { field = "general", error = argEx.Message });
            }
            else // Erro inesperado
            {
                errors.Add(new { field = "general", error = "Ocorreu um erro inesperado. Tente novamente mais tarde." });
            }

            return new { errors };
        }
    }
}
