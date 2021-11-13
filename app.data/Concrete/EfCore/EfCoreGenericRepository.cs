using System.Collections.Generic;
using System.Linq;
using app.data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace app.data.Concrete.EfCore
{
    public class EfCoreGenericRepository<Tentity, Tcontext> : IRepository<Tentity>
    where Tentity : class
    where Tcontext : DbContext, new()

    {
        public void Create(Tentity Entity)
        {
            using(var context = new Tcontext())
            {
                context.Set<Tentity>().AddRange(Entity);
                context.SaveChanges();
            }
        }

        public void Delete(Tentity Entity)
        {
            using(var context = new Tcontext())
            {
                context.Set<Tentity>().Remove(Entity);
                context.SaveChanges();
            }
        }

        public List<Tentity> GetAll()
        {
            using(var context = new Tcontext())
            {
                return context.Set<Tentity>().ToList();
            }
        }

        public Tentity GetById(int id)
        {
            using(var context = new Tcontext())
            {
                return context.Set<Tentity>().Find(id);
            }
        }

        public virtual void Update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}