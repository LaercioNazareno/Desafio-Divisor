using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;

namespace Desafio.Data.Repositories
{
    // Configurar em um servidor de banco de dados
    // para disponibilizar as análises para diferentes 
    // usuários.
    public class Repository : IRepository
    {
        private static readonly string PATH_REPOSITORY = "../../4-infra/4.1-Data/Desafio.Data/Divisors.json";
        public Divisor GetDivisorsCalculatedBy(int number)
        {
            var results = GetAll();
            return results.FindLast(x => x.Number == number);
        }
        private List<Divisor> GetAll()
        {
            var results = new List<Divisor>();
            using (StreamReader r = new(PATH_REPOSITORY))
            {
                string json = r.ReadToEnd();
                results = JsonSerializer.Deserialize<List<Divisor>>(json);
            }
            return results;
        }
        public void Save(Divisor divisor)
        {
            List<Divisor> _data = GetAll();
            _data.Add(divisor);
            string json = JsonSerializer.Serialize(_data);
            File.WriteAllText(PATH_REPOSITORY, json);
        }
    }
}