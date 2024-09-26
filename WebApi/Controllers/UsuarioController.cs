//using AllBoroTours.API.ViewModels;
//using FluentValidation;
//using FluentValidation.Results;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using AllBoroTours.Infrastructure.Data.Identity.Services.Interfaces;
//using AllBoroTours.Domain.Interfaces.Account;


//namespace WebApi.Controllers
//{
//    [Route("api/v1/[controller]")]
//    [ApiController]
//    public class UsuarioController : ControllerBase
//    {
//        private readonly IUsuarioService _usuarioService;
//        private readonly IUsuarioLogado _usuarioLogado;
//        private readonly IValidator<UsuarioCadastro> _validator;

//        public UsuarioController(IUsuarioService usuarioService, IValidator<UsuarioCadastro> validator, IUsuarioLogado usuarioLogado) {
//            _usuarioService = usuarioService;
//            _validator = validator;
//            _usuarioLogado = usuarioLogado;
//        }


//        [HttpGet]
//        [Authorize(Roles = "superadmin,admin")]
//        public async Task<ActionResult<IEnumerable<UsuarioCadastro>>> Get() {
//            var usuarios = await _usuarioService.GetAll();

//            if (!usuarios.Any()) {
//                return NotFound("Usuários não encontrados.");
//            }

//            var usuariosViewModel = new List<UsuarioInfo>();
//            for (int i = 0; i < usuarios.Count(); i++) {
//                usuariosViewModel.Add(new UsuarioInfo() {
//                    Nome = usuarios.ElementAt(i).Nome,
//                    Sobrenome = usuarios.ElementAt(i).Sobrenome,
//                    Email = usuarios.ElementAt(i).Email,
//                    Telefone = usuarios.ElementAt(i).PhoneNumber,
//                    DataNascimento = usuarios.ElementAt(i).DataNascimento
//                });
//            }

//            return Ok(usuariosViewModel);
//        }


//        [HttpGet]
//        [Route("Informacao")]
//        [Authorize]
//        public async Task<ActionResult<UsuarioInfo>> GetUsuario() {
//            var usuario = await _usuarioService.GetById(_usuarioLogado.Id);

//            if (usuario == null) {
//                return NotFound("Usuário não encontrado.");
//            }

//            var usuarioViewModel = new UsuarioInfo() {
//                Nome = usuario.Nome,
//                Sobrenome = usuario.Sobrenome,
//                Email = usuario.Email,
//                Telefone = usuario.PhoneNumber,
//                DataNascimento = usuario.DataNascimento,
//                Perfil = await _usuarioService.GetPerfisPorUsuario(usuario)
//            };

//            return Ok(usuarioViewModel);
//        }



//        [HttpPost]
//        [Route("Cliente")]
//        [AllowAnonymous]
//        public async Task<ActionResult> CriarUsuarioCliente([FromBody] UsuarioCadastro usuarioCadastro) {
//            ValidationResult validationResult = await _validator.ValidateAsync(usuarioCadastro);

//            if (!validationResult.IsValid) {
//                return BadRequest(validationResult.Errors);
//            }
//            if (await _usuarioService.VerificaUsuarioCadastrado(usuarioCadastro.Email)) {
//                return BadRequest($"Já existe um e-mail {usuarioCadastro.Email} cadastrdo.");
//            }

//            var result = await _usuarioService.InserirUsuarioCliente(usuarioCadastro.Nome, usuarioCadastro.Sobrenome, usuarioCadastro.Email,
//                                                                     usuarioCadastro.Telefone, usuarioCadastro.DataNascimento.Date, usuarioCadastro.Senha);

//            if (!result) return BadRequest("Erro ao criar usuário.");

//            return Ok($"O usuário {usuarioCadastro.Email} foi criado com sucesso.");
//        }



//        [HttpPost]
//        [Route("Especifico")]
//        [Authorize(Roles = "superadmin")]
//        public async Task<ActionResult> CriarUsuario([FromBody] UsuarioCadastro usuarioCadastro) {
//            ValidationResult validationResult = await _validator.ValidateAsync(usuarioCadastro);

//            if (!validationResult.IsValid) {
//                return BadRequest(validationResult.Errors);
//            }

//            if (await _usuarioService.VerificaUsuarioCadastrado(usuarioCadastro.Email)) {
//                return BadRequest($"Já existe um e-mail {usuarioCadastro.Email} cadastrdo.");
//            }

//            var result = await _usuarioService.InserirUsuario(usuarioCadastro.Nome, usuarioCadastro.Sobrenome, usuarioCadastro.Email, usuarioCadastro.Telefone,
//                                                              usuarioCadastro.DataNascimento.Date, usuarioCadastro.Perfil, usuarioCadastro.Senha);

//            if (!result) return BadRequest("Erro ao criar usuário.");

//            return Ok($"O usuário {usuarioCadastro.Email} foi criado com sucesso.");
//        }






//    }
//}
