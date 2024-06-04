using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserIdTests
{

    private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserIdTests()
    {
        _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        _logger = loggerFactory.CreateLogger<AspNetUser>();
    }

    private void SetupClaimsPrincipal(IEnumerable<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);
        _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);
    }

    [Fact]
    public void GetUserId_ReturnsCorrectId_WhenClaimPresent()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) };
        SetupClaimsPrincipal(claims);

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var resultId = aspNetUser.GetUserId();

        // Assert
        Assert.Equal(userId, resultId);
    }

    [Fact]
    public void GetUserId_ReturnsEmptyGuid_WhenClaimNotPresent()
    {
        // Arrange
        SetupClaimsPrincipal(new List<Claim>());

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var resultId = aspNetUser.GetUserId();

        // Assert
        Assert.Equal(Guid.Empty, resultId);
    }


}
