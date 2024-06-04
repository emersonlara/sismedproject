using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

public class AspNetUserGetClaimsIdentityTests
{
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserGetClaimsIdentityTests()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        _logger = loggerFactory.CreateLogger<AspNetUser>();
    }

    [Fact]
    public void GetClaimsIdentity_ReturnsAllUserClaims()
    {
        // Arrange
        var claims = new List<Claim>
    {
        new Claim("Type1", "Value1"),
        new Claim("Type2", "Value2"),
        new Claim("Type3", "Value3")
    };
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

        var aspNetUser = new AspNetUser(mockHttpContextAccessor.Object, _logger);

        // Act
        var returnedClaims = aspNetUser.GetClaimsIdentity();

        // Assert
        Assert.NotNull(returnedClaims);
        Assert.Equal(claims.Count, returnedClaims.Count());
        foreach (var claim in claims)
        {
            Assert.Contains(returnedClaims, c => c.Type == claim.Type && c.Value == claim.Value);
        }
    }
}
