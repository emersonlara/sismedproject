//using System.Security.Claims;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Options;
//using Moq;
//using SisMedico.Mvc.Data;
//using SisMedico.Mvc.Extensions;
//using SisMedico.Mvc.Extensions.IdentityServices;

//public class UserClaimsServiceTests
//{
//    [Fact]
//    public async Task CreateAsync_AddsClaimsToPrincipal()
//    {
//        // Arrange
//        var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
//        var userManagerMock = new UserManager<ApplicationUser>(userStoreMock.Object, null, null, null, null, null, null, null, null);
//        var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
//        var roleManagerMock = new RoleManager<IdentityRole>(roleStoreMock.Object, null, null, null, null);
//        var optionsMock = new Mock<IOptions<IdentityOptions>>();
//        var dbContextMock = new Mock<ApplicationDbContext>();
//        var user = new ApplicationUser
//        {
//            Apelido = "TestApelido",
//            NomeCompleto = "Test Nome Completo",
//            Email = "test@example.com",
//            DataNascimento = new DateTime(2000, 1, 1),
//            ImgProfilePath = "test/path"
//        };

//        var service = new UserClaimsService(dbContextMock.Object, userManagerMock, roleManagerMock, optionsMock.Object);

//        // Act
//        var principal = await service.CreateAsync(user);

//        // Assert
//        var identity = Assert.IsType<ClaimsIdentity>(principal.Identity);
//        Assert.Equal(user.Apelido, identity.FindFirst("Apelido")?.Value);
//        Assert.Equal(user.NomeCompleto, identity.FindFirst("NomeCompleto")?.Value);
//        Assert.Equal(user.Email, identity.FindFirst("Email")?.Value);
//        Assert.Equal(user.DataNascimento.ToBrazilianDate(), identity.FindFirst("DataNascimento")?.Value);
//        Assert.Equal(user.ImgProfilePath, identity.FindFirst("ImgProfilePath")?.Value);
//    }
//}
