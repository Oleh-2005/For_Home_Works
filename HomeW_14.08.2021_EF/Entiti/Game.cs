using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW_14._08._2021_EF.Entiti
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public string Stayle { get; set; }
        public DateTime Reliase { get; set; }
        public bool MultiplayOrNot { get; set; }
        public int NumberOfSells { get; set; }
    }
}
