using CRUDProject.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Shared.Repositories
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
    }


}
