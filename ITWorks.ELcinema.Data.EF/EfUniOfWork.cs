using ItworksElcenima.Domain;
using ItworksElcenima.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.ELcinema.Data.EF
{
    public class EfUniOfWork : DbContext ,IUnitOfWork
    {
        public EfUniOfWork() :base("Elcinema")//a3ml database asmha elcinema
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfUniOfWork>()); // automatic maigration //mohmafahsh5
        }
        public DbSet<Movie> Movies { get; set; } //eltable
        public DbSet<Country> Countries { get; set; } 

        public void Commit()
        {
            SaveChanges(); //lma 7ad y2olii COMMIT
        }

        public Task CommitAsync()
        {
           return  SaveChangesAsync(); // 2i 7aga async lazm trag3 task !
        }

  
    }
}
