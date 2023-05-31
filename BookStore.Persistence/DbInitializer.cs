using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(BookStoreDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
