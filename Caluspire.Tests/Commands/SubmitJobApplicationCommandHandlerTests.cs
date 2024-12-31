using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Tests.Commands
{
    public class SubmitJobApplicationCommandHandlerTests
    {
        private readonly Mock<IJobRepository> _mockJobRepository;
        private readonly SubmitJobApplicationCommandHandler _handler;

        public SubmitJobApplicationCommandHandlerTests()
        {
            _mockJobRepository = new Mock<IJobRepository>();
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
                CandidateSkills = "C#"
            };

            var job = new Job(1, "Software Engineer", "Develops software");
            _mockJobRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(job);

            await _handler.Handle(command, CancellationToken.None);

            Assert.Single(job.Candidates);
            Assert.Equal("Jaouad", job.Candidates[0].Name);
        }
    }

}
