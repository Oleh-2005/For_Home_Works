using HomeW_14._08._2021_EF.Entiti;
using System;
using System.Data.Entity;
using System.Linq;

namespace HomeW_14._08._2021_EF
{
    public class GamesDB : DbContext
    {
        
        public GamesDB()
            : base("name=GamesDB")
        {
        }

        
         public virtual DbSet<Game> Games { get; set; }
    }
}