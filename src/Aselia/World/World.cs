using Aselia.src.Aselia.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aselia.src.Aselia.World {
    internal class World {
        private Player.Player player;

        public World() {
            player = new Player.Player();
        }

        public void tick() {
            player.tick();
        }

        public void render() {
            player.render();
        }
    }

    internal class Column {

    }

    internal class Chunk {

    }
}
