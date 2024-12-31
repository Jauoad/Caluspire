using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Caluspire.Web.Models;

namespace Caluspire.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly HttpClient _httpClient;

        public JobController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:5001/api/jobs");
            var jobs = await response.Content.ReadAsAsync<IEnumerable<JobApplicationViewModel>>();

            return View(jobs);
        }

        public IActionResult SubmitApplication(int jobId)
        {
            return View(new JobApplicationViewModel { JobId = jobId });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication(JobApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/jobApplications", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Job");
                }

                ModelState.AddModelError("", "Error submitting application");
            }
            return View(model);
        }
    }
}
