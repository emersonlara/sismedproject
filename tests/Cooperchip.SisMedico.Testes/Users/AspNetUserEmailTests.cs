using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserEmailTests
{

    private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserEmailTests()
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
    public void GetUserEmail_ReturnsCorrectEmail_WhenClaimPresent()
    {
        // Arrange
        var email = "test@example.com";
        var claims = new List<Claim> { new Claim("Email", email) };
        SetupClaimsPrincipal(claims);

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var userEmail = aspNetUser.GetUserEmail();

        // Assert
        Assert.Equal(email, userEmail);
    }

    [Fact]
    public void GetUserEmail_ReturnsEmpty_WhenClaimNotPresent()
    {
        // Arrange
        SetupClaimsPrincipal(new List<Claim>());

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var userEmail = aspNetUser.GetUserEmail();

        // Assert
        Assert.Equal("", userEmail);
    }


}
