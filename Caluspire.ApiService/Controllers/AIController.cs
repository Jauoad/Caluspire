using Microsoft.AspNetCore.Mvc;
using Caluspire.AI.Models;
using Caluspire.AI.Services;

namespace Caluspire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly MLModelService _mlModelService;

        public AIController(MLModelService mlModelService)
        {
            _mlModelService = mlModelService;
        }

        [HttpPost("predict")]
        public ActionResult<float> Predict([FromBody] InputData input)
        {
            try
            {
                var prediction = _mlModelService.Predict(input);
                return Ok(prediction);
            }
            catch (Exception ex)
            {
                return BadRequest($"Machine Learning predection error : {ex.Message}");
            }
        }
    }
}

