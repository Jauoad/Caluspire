using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly IMediator _mediator;

    public CandidateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Apply
    [HttpPost("apply")]
    public async Task<IActionResult> ApplyForJob([FromBody] SubmitJobApplicationCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    // Get candidate details 
    [HttpGet("details/{candidateId}")]
    public async Task<IActionResult> GetCandidateDetails(int candidateId)
    {
        var query = new GetCandidateDetailsQuery { CandidateId = candidateId };
        var candidate = await _mediator.Send(query);
        return Ok(candidate);
    }
}
