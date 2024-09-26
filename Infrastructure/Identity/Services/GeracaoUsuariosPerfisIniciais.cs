using Domain.Entities;
using Infrastructure.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Identity.Services
{
    public class GeracaoUsuariosPerfisIniciais : IGeracaoUsuariosPerfisIniciais
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Perfil> _roleManager;

        public GeracaoUsuariosPerfisIniciais(RoleManager<Perfil> roleManager,
              UserManager<Usuario> userManager) {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void GerarPerfis() {
            if (!_roleManager.RoleExistsAsync("atendente").Result) {
                Perfil perfil = new();
                perfil.Name = "atendente";
                perfil.NormalizedName = perfil.Name.ToUpper();
                IdentityResult roleResult = _roleManager.CreateAsync(perfil).Result;
            }

        }

        public void GerarUsuarios() {
            if (_userManager.FindByNameAsync("atendente@user.com.br").Result == null) {
                Usuario usuario = new();
                usuario.Name = "Atendente";
                usuario.UserName = "atendente@user.com.br";
                usuario.NormalizedUserName = usuario.UserName.ToUpper();
                usuario.Email = usuario.UserName;
                usuario.NormalizedEmail = usuario.Email.ToUpper();
                usuario.LockoutEnabled = false;
                usuario.SecurityStamp = Guid.NewGuid().ToString();
                usuario.PhoneNumber = "38123456789";

                IdentityResult result = _userManager.CreateAsync(usuario, "Teste1@").Result;

                if (result.Succeeded) {
                    _userManager.AddToRoleAsync(usuario, "atendente").Wait();
                }
            }
        }

    }
}
