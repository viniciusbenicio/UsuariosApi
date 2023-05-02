using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task Cadastrar(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar Usuário.");
            }

        }

        public async Task Login(LoginUsuarioDto dto)
        {
           var resultado = await _signInManager.PasswordSignInAsync(dto.userName, dto.password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }
        }
    }
}
