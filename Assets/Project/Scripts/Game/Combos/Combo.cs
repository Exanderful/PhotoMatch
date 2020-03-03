using System.Collections.Generic;

using UnityEngine;

namespace GEM.Game.Common
{
    /// <summary>
    /// The base class of the combos.
    /// </summary>
    public abstract class Combo
    {
        public Tile tileA;
        public Tile tileB;

        /// <summary>
        /// Resolves this combo.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tiles">The tiles destroyed by the combo.</param>
        /// <param name="fxPool">The pool to use for the visual effects.</param>
        public abstract void Resolve(GameBoard board, List<GameObject> tiles, FxPool fxPool);
    }
}