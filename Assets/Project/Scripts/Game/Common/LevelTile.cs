namespace GEM.Game.Common
{
    /// <summary>
    /// The base class used for the tiles in the visual editor.
    /// </summary>
    public class LevelTile
    {
        public ElementType elementType;
    }

    /// <summary>
    /// The class used for candy tiles.
    /// </summary>
    public class CandyTile : LevelTile
    {
        public CandyType type;
    }

    /// <summary>
    /// The class used for special candy tiles.
    /// </summary>
    public class SpecialCandyTile : LevelTile
    {
        public SpecialCandyType type;
    }

    /// <summary>
    /// The class used for special block tiles.
    /// </summary>
    public class SpecialBlockTile : LevelTile
    {
        public SpecialBlockType type;
    }

    /// <summary>
    /// The class used for collectable tiles.
    /// </summary>
    public class CollectableTile : LevelTile
    {
        public CollectableType type;
    }

    /// <summary>
    /// The class used for hole tiles.
    /// </summary>
    public class HoleTile : LevelTile
    {
    }
}