using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backupPokemon.Model
{
    public class PokemonModel
    {
        [Key]
        public int id { get; set; }

        
        public string name { get; set; }

        
        public string type { get; set; }

      
        public bool gender { get; set; }

        public int weight { get; set; }

       
        public int height { get; set; }

    }
}
