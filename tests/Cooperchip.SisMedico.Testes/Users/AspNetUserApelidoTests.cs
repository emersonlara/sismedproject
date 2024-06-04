using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using SisMedico.Domain.Extensions.Helpers;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserApelidoTests
{
    private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserApelidoTests()
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
    public void GetUserApelido_ReturnsCorrectApelido_WhenClaimPresent()
    {
        // Arrange
        var apelido = "Nickname";
        var claims = new List<Claim> { new Claim("Apelido", apelido) };
        SetupClaimsPrincipal(claims);

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var userApelido = aspNetUser.GetUserApelido();

        // Assert
        Assert.Equal(apelido, userApelido);
    }

    [Fact]
    public void GetUserApelido_ReturnsEmpty_WhenClaimNotPresent()
    {
        // Arrange
        SetupClaimsPrincipal(new List<Claim>());

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var userApelido = aspNetUser.GetUserApelido();

        // Assert
        Assert.Equal("", userApelido);
    }

}
