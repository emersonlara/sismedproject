using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserIsInRoleTests
{
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserIsInRoleTests()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        _logger = loggerFactory.CreateLogger<AspNetUser>();
    }

    [Fact]
    public void IsInRole_UserInRole_ReturnsTrue()
    {
        // Arrange
        var roleName = "Admin";
        var claims = new List<Claim> { new Claim(ClaimTypes.Role, roleName) };
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

        var aspNetUser = new AspNetUser(mockHttpContextAccessor.Object, _logger);

        // Act
        var isInRole = aspNetUser.IsInRole(roleName);

        // Assert
        Assert.True(isInRole);
    }

    // Outros testes relevantes para IsInRole podem ser adicionados aqui
}
