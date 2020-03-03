namespace GEM.Game.Common
{
    /// <summary>
    /// Utility type to represent a level tile, identified by its x and y coordinates.
    /// </summary>
    public struct TileDef
    {
        public readonly int x;
        public readonly int y;

        public TileDef(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}