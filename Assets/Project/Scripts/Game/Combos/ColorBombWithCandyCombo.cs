using System.Collections.Generic;

using UnityEngine;

using GEM.Core;

namespace GEM.Game.Common
{
    /// <summary>
    /// The class used for the color bomb + candy combo.
    /// </summary>
    public class ColorBombWithCandyCombo : ColorBombCombo
    {
        /// <summary>
        /// Resolves this combo.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tiles">The tiles destroyed by the combo.</param>
        /// <param name="fxPool">The pool to use for the visual effects.</param>
        public override void Resolve(GameBoard board, List<GameObject> tiles, FxPool fxPool)
        {
            base.Resolve(board, tiles, fxPool);

            var candy = tileA.GetComponent<Candy>() != null ? tileA : tileB;

            foreach (var tile in tiles.ToArray())
            {
                if (tile != null && tile.GetComponent<Candy>() != null &&
                    tile.GetComponent<Candy>().color == candy.GetComponent<Candy>().color)
                {
                    board.ExplodeTileNonRecursive(tile);
                }
            }

            SoundManager.instance.PlaySound("ColorBomb");

            board.ApplyGravity();
        }
    }
}