using System.Security.Claims;
using SisMedico.Domain.Extensions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cooperchip.SisMedico.Testes.Users;

//public class AspNetUserImgProfilePathTests
//{
//    private readonly ILogger<AspNetUser> _logger;

//    public AspNetUserImgProfilePathTests()
//    {
//        var loggerFactory = LoggerFactory.Create(builder =>
//        {
//            builder.AddConsole();
//        });
//        _logger = loggerFactory.CreateLogger<AspNetUser>();
//    }

//    [Fact]
//    public void GetUserImgProfilePath_ReturnsCorrectPath()
//    {
//        // Arrange
//        var imgPath = "path/to/image.jpg";
//        var claims = new List<Claim> { new Claim("ImgProfilePath", imgPath) };
//        var identity = new ClaimsIdentity(claims);
//        var claimsPrincipal = new ClaimsPrincipal(identity);

//        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
//        mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

//        var aspNetUser = new AspNetUser(mockHttpContextAccessor.Object, _logger);

//        // Act
//        var userImgProfilePath = aspNetUser.GetUserImgProfilePath();

//        // Assert
//        Assert.Equal(imgPath, userImgProfilePath);
//    }
//}


public class AspNetUserImgProfilePathTests
{
    private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    private readonly ILogger<AspNetUser> _logger;

    public AspNetUserImgProfilePathTests()
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
    public void GetUserImgProfilePath_ReturnsCorrectPath_WhenClaimPresent()
    {
        // Arrange
        var imgPath = "path/to/image.jpg";
        var claims = new List<Claim> { new Claim("ImgProfilePath", imgPath) };
        SetupClaimsPrincipal(claims);

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var userImgProfilePath = aspNetUser.GetUserImgProfilePath();

        // Assert
        Assert.Equal(imgPath, userImgProfilePath);
    }

    [Fact]
    public void GetUserImgProfilePath_ReturnsEmpty_WhenClaimNotPresent()
    {
        // Arrange
        SetupClaimsPrincipal(new List<Claim>());

        var aspNetUser = new AspNetUser(_mockHttpContextAccessor.Object, _logger);

        // Act
        var userImgProfilePath = aspNetUser.GetUserImgProfilePath();

        // Assert
        Assert.Equal("", userImgProfilePath);
    }

    // Similar tests for other methods...
}
