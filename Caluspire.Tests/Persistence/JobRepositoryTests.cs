namespace Caluspire.Tests;

[TestClass]
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
        var job = new Job(1, "Software Engineer");
        _mockContext.Setup(m => m.Jobs.FindAsync(It.IsAny<int>())).ReturnsAsync(job);

        var result = await _jobRepository.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Software Engineer", result.Title);
    }
}

