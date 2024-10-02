using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Shared.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string GameName { get; set; }

    }
}
