using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Model
{
    public class GameSettings: IGameSettings
    {
        public int StartSize { get; set; }

        public float TileSize { get; set; }
        public float CrystalChance { get; set; }
    }
}
