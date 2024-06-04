using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserIsAuthenticatedTests
{
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserIsAuthenticatedTests()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        _logger = loggerFactory.CreateLogger<AspNetUser>();
    }

    [Fact]
    public void IsAuthenticated_UserAuthenticated_ReturnsTrue()
    {
        // Arrange
        var identity = new ClaimsIdentity("TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

        var aspNetUser = new AspNetUser(mockHttpContextAccessor.Object, _logger);

        // Act
        var isAuthenticated = aspNetUser.IsAuthenticated();

        // Assert
        Assert.True(isAuthenticated);
    }

    // Outros testes relevantes para IsAuthenticated podem ser adicionados aqui
}
