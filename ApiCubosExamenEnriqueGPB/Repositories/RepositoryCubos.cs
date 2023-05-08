using ApiCubosExamenEnriqueGPB.Data;
using ApiCubosExamenEnriqueGPB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCubosExamenEnriqueGPB.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;
        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }
        public async Task<List<Cubo>> GetCubosMarcaAsync(string marca)
        {
            return await this.context.Cubos.Where(x => x.Marca == marca).ToListAsync();
        }
        public async Task<Cubo> FindCubosAsync(int idcubo)
        {
            return await this.context.Cubos.FirstOrDefaultAsync(x => x.IdCubo == idcubo);
        }

        public async Task NewCuboAsync(Cubo cubo)
        {
            Cubo cubonuevo = new Cubo
            {
                IdCubo = cubo.IdCubo,
                Nonbre = cubo.Nonbre,
                Marca = cubo.Marca,
                Imagen = cubo.Imagen,
                Precio = cubo.Precio,
            };

            this.context.Cubos.Add(cubonuevo);
            await this.context.SaveChangesAsync();
        }

        
    }
}
