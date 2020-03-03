using UnityEngine;

namespace GEM.Game.Common
{
    /// <summary>
    /// The base class of the in-game boosters.
    /// </summary>
    public abstract class Booster
    {
        /// <summary>
        /// Resolves this booster.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tile">The tile in which to apply the booster.</param>
        public abstract void Resolve(GameBoard board, GameObject tile);
    }
}