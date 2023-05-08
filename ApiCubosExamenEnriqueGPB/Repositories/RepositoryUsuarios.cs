using ApiCubosExamenEnriqueGPB.Data;
using ApiCubosExamenEnriqueGPB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCubosExamenEnriqueGPB.Repositories
{
    public class RepositoryUsuarios
    {
        private CubosContext context;

        public RepositoryUsuarios(CubosContext context)
        {
            this.context = context;
        }

        public async Task NewUsuario(UsuarioCubo usuario)
        {
            UsuarioCubo nuevousuario =
                new UsuarioCubo
                {
                    IdUsuario = usuario.IdUsuario,
                    Nonbre = usuario.Nonbre,
                    Email = usuario.Email,
                    Imagen = usuario.Imagen,
                    Pass = usuario.Pass
                };

            this.context.UsuarioCubos.Add(nuevousuario);
            await this.context.SaveChangesAsync();
        }

        public async Task<UsuarioCubo>FindUsuarioCubosAsync(int idusuario)
        {
            return await this.context.UsuarioCubos.FirstOrDefaultAsync(x => x.IdUsuario == idusuario);

        }

        public async Task<List<CompraCubo>> GetPedidosAsync(int idusuario)
        {
            return await this.context.CompraCubos.Where(x => x.IdUsuario == idusuario).ToListAsync();
        }

        public async Task NewPedido(CompraCubo compraCubo)
        {
            CompraCubo nuevaCompra =
                new CompraCubo
                {
                    IdUsuario = compraCubo.IdUsuario,
                    IdCubo = compraCubo.IdCubo,
                    IdPedido = compraCubo.IdPedido,
                    Imagen = compraCubo.Imagen,
                    Marca = compraCubo.Marca,
                    Nonbre = compraCubo.Nonbre,
                    Precio = compraCubo.Precio
                    
                };

            this.context.CompraCubos.Add(nuevaCompra);
            await this.context.SaveChangesAsync();
        }
        public async Task<UsuarioCubo> ExisteUsuarioAsync(string email, string pass)
        {
            return await this.context.UsuarioCubos.FirstOrDefaultAsync(x => x.Email == email && x.Pass == pass);
        }
    }
}
