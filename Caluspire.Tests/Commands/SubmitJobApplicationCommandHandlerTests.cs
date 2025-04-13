using Xunit;
using NUnit.Framework;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Caluspire.Application.Commands;
using Caluspire.Application.Handlers;
using Caluspire.Application.Repositories;
using Caluspire.Domain.Entities;
using Caluspire.Domain.Repositories;

namespace Caluspire.Tests.Commands
{
    public class SubmitJobApplicationCommandHandlerTests
    {
        private readonly Mock<Application.Repositories.IJobRepository> _mockJobRepository;
        private readonly SubmitJobApplicationCommandHandler _handler;

        public SubmitJobApplicationCommandHandlerTests()
        {
            _mockJobRepository = new Mock<Application.Repositories.IJobRepository>();
            _handler = new SubmitJobApplicationCommandHandler(_mockJobRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddCandidateToJob()
        {
            var command = new SubmitJobApplicationCommand
            {
                JobId = 1,
                CandidateId = 1,
                CandidateName = "Jaouad",
                CandidateSkills = new List<string> { "C#" }
            };

            var job = new Job(1, "Software Engineer",".NET Engineer");
            _mockJobRepository.Setup(r => r.GetJobByIdAsync(It.IsAny<int>())).ReturnsAsync(job);

            await _handler.Handle(command, CancellationToken.None);

            Xunit.Assert.Single(job.Candidates);
            Xunit.Assert.Equal("Jaouad", job.Candidates[0].Name);
        }
    }
}