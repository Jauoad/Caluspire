using Xunit;
using Moq;
using Caluspire.Domain.Entities;
using Caluspire.Infrastructure.Persistence;
using Caluspire.Infrastructure;

namespace Caluspire.Tests
{
    public class JobRepositoryTests
    {
        private readonly JobRepository _jobRepository;
        private readonly Mock<ApplicationDbContext> _mockContext;

        public JobRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _jobRepository = new JobRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnJob()
        {
            var job = new Job(1, "Software Engineer", ".NET Engineer");
            _mockContext.Setup(m => m.Jobs.FindAsync(It.IsAny<int>())).ReturnsAsync(job);
            var result = await _jobRepository.GetJobByIdAsync(1);

            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal("Software Engineer", result.Title);
        }
    }
}