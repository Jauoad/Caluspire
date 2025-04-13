using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Caluspire.Web.Models;

namespace Caluspire.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly HttpClient _httpClient;

        public CandidateController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Details(int candidateId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5001/api/candidates/{candidateId}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var candidate = JsonSerializer.Deserialize<CandidateViewModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(candidate);
        }
    }
}