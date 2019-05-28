using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyGameScore.Models
{
    public class MyGameScoreContext : DbContext
    {
        public MyGameScoreContext (DbContextOptions<MyGameScoreContext> options)
            : base(options)
        {
        }

        public DbSet<GameScore> GameScore { get; set; }
    }
}
