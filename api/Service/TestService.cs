using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Service
{
    public class TestService
    {    
        private readonly HttpClient _client;

        public TestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Stock?> TestServiceMethod(int id) 
        {

            Stock? user = await _client.GetFromJsonAsync<Stock?>($"/todos/{id}");

            return user;
        }
    }

    // public interface IMovieService
    // {
    //     User? TestServiceMethod();
    // }
}