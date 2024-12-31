using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
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
            // Appel API pour obtenir les détails du candidat
            var response = await _httpClient.GetAsync($"https://localhost:5001/api/candidates/{candidateId}");
            var candidate = await response.Content.ReadAsAsync<CandidateViewModel>();

            return View(candidate);
        }
    }
}
