using System.Collections.Generic;

using UnityEngine;

using GEM.Core;

namespace GEM.Game.Common
{
    /// <summary>
    /// The base class of the combos that involve a color bomb.
    /// </summary>
    public class ColorBombCombo : Combo
    {
        /// <summary>
        /// Resolves this combo.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tiles">The tiles destroyed by the combo.</param>
        /// <param name="fxPool">The pool to use for the visual effects.</param>
        public override void Resolve(GameBoard board, List<GameObject> tiles, FxPool fxPool)
        {
            var bomb = tileA.GetComponent<ColorBomb>() != null ? tileA : tileB;
            board.ExplodeTileNonRecursive(bomb.gameObject);

            var explosion = fxPool.photoBombExplosion.GetObject();
            explosion.transform.position = tileB.transform.position;

            SoundManager.instance.PlaySound("ColorBomb");
        }
    }
}