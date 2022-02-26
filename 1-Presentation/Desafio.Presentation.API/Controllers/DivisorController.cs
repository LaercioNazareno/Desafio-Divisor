using Microsoft.AspNetCore.Mvc;
using Desafio.Application.Interfaces;
using Desafio.Presentation.API.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Desafio.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisorController : ControllerBase
    {
        private readonly IUseCaseDivisibility _useCaseDivisibility;

        public DivisorController(IUseCaseDivisibility useCaseDivisibility)
        {
            _useCaseDivisibility = useCaseDivisibility;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int number)
        {
            try
            {
                if (number > 0)
                {
                    var divisor = _useCaseDivisibility.GetDivisors(number);
                    var data = JsonSerializer.Serialize(divisor);
                    return Ok(
                        new ResultModel()
                        {
                            StatusCode = 200,
                            Data = data,
                            Description = "Concluido com sucesso"
                        }
                    );

                }
                else
                {
                    return BadRequest(
                        new ResultModel()
                        {
                            StatusCode = 400,
                            Data = string.Empty,
                            Description = "Valores menores que 0 não são válidos, favor informar um número maior que 0"
                        }
                    );
                }

            }
            catch (System.Exception e)
            {
                return Problem(
                    e.Message,
                    e.StackTrace,
                    StatusCodes.Status500InternalServerError,
                    "Favor entrar em contato com a equipe",
                    string.Empty
                );
            }

        }
    }
}
