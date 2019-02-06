namespace Assets.Scripts.Game.Model
{
    public interface IGameSettings
    {
        int StartSize { get; set; }

        float TileSize { get; set; }

        float CrystalChance { get; set; }
    }
}
