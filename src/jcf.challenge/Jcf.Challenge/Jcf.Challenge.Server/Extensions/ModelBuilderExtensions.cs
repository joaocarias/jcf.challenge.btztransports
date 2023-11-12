using Jcf.Challenge.Server.Extensions.Contants;
using Jcf.Challenge.Server.Extensions.Utils;
using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Jcf.Challenge.Server.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = Guid.Parse("08dbd59a-2683-4c67-8e16-689ba2648545"),
                        Name = "Administrador Usuário",
                        Email = "admin@email.com",
                        UserName = "admin@email.com",
                        Password = PasswordUtil.CreateHashMD5("102030"),
                        Role = RolesConstant.ADMIN
                    },
                    new User
                    {
                        Id = Guid.Parse("08dbdc08-56e1-4e90-805f-db29361e075e"),
                        Name = "Básico Usuário",
                        Email = "basico@email.com",
                        UserName = "basico@email.com",
                        Password = PasswordUtil.CreateHashMD5("102030"),
                        Role = RolesConstant.BASIC
                    }
                ) ;
        }
    }
}
