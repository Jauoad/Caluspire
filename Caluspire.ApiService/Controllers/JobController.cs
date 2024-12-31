using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Submit candidate
    [HttpPost("submit")]
    public async Task<IActionResult> SubmitJobApplication([FromBody] SubmitJobApplicationCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    // Get status
    [HttpGet("status/{candidateId}")]
    public async Task<IActionResult> GetApplicationStatus(int candidateId)
    {
        var query = new GetJobApplicationStatusQuery { CandidateId = candidateId };
        var status = await _mediator.Send(query);
        return Ok(status);
    }
}
