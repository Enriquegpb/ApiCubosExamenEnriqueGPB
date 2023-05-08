using ApiCubosExamenEnriqueGPB.Models;
using ApiCubosExamenEnriqueGPB.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiCubosExamenEnriqueGPB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;
        private RepositoryUsuarios repoOperacionesProtegidas;
        public CubosController(RepositoryCubos repo, RepositoryUsuarios repoOperacionesProtegidas)
        {
            this.repo = repo;
            this.repoOperacionesProtegidas = repoOperacionesProtegidas;
        }

        [HttpGet]
        
        public async Task<ActionResult<List<Cubo>>> GetCubos()
        {
            List<Cubo> cubos = await this.repo.GetCubosAsync();
            return cubos;

        } 
        [HttpGet]
        [Route("[action]/{marca}")]
        public async Task<ActionResult<List<Cubo>>> GetCubos(string marca)
        {
            List<Cubo> cubos = await this.repo.GetCubosMarcaAsync(marca);
            return cubos;

        }

        [HttpPost]
        public async Task<ActionResult> NewUsuario(Cubo cubo)
        {
           await this.repo.NewCuboAsync(cubo);
           return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<ActionResult<UsuarioCubo>> GetPerfilUsuario()
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario =
                claim.Value;
            UsuarioCubo usuario =
                JsonConvert.DeserializeObject<UsuarioCubo>(jsonUsuario);
            return usuario;
        }
        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CompraCubo>>> GetPedidosUsuario()
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario =
                claim.Value;
            UsuarioCubo usuario =
                JsonConvert.DeserializeObject<UsuarioCubo>(jsonUsuario);
            List<CompraCubo> cubos = await this.repoOperacionesProtegidas.GetPedidosAsync(usuario.IdUsuario);
            return cubos;
        } 
        [Route("[action]")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RealizarPedidoUsuario(CompraCubo cubo)
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario =
                claim.Value;
            UsuarioCubo usuario =
                JsonConvert.DeserializeObject<UsuarioCubo>(jsonUsuario);
            cubo.IdUsuario = usuario.IdUsuario;
            await this.repoOperacionesProtegidas.NewPedido(cubo);
            return Ok();
        }
    }
}
