using System.Text.Json;

namespace Desafio.Presentation.API.Models
{
    public class ResultModel
    {
        public int StatusCode { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
    }
}