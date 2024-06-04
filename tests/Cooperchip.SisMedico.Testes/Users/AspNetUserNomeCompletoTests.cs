using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserNomeCompletoTests
{
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserNomeCompletoTests()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        _logger = loggerFactory.CreateLogger<AspNetUser>();
    }

    [Fact]
    public void GetUserNomeCompleto_ReturnsCorrectName()
    {
        // Arrange
        var claims = new List<Claim> { new Claim("NomeCompleto", "John Doe") };
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

        var aspNetUser = new AspNetUser(mockHttpContextAccessor.Object, _logger);

        // Act
        var nomeCompleto = aspNetUser.GetUserNomeCompleto();

        // Assert
        Assert.Equal("John Doe", nomeCompleto);
    }

    // Outros testes relevantes para NomeCompleto podem ser adicionados aqui
}
