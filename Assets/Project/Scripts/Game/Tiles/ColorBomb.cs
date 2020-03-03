using System.Collections.Generic;

using UnityEngine;

using GEM.Core;

namespace GEM.Game.Common
{
    /// <summary>
    /// The class used for color bombs.
    /// </summary>
    public class ColorBomb : Tile
    {
        /// <summary>
        /// Returns a list containing all the tiles destroyed when this tile explodes.
        /// </summary>
        /// <returns>A list containing all the tiles destroyed when this tile explodes.</returns>
        public override List<GameObject> Explode()
        {
            return new List<GameObject>() {gameObject};
        }

        /// <summary>
        /// Shows the visual effects associated to the explosion of this tile.
        /// </summary>
        /// <param name="pool">The pool to use for the visual effects.</param>
        public override void ShowExplosionFx(FxPool pool)
        {
            var explosion = pool.photoBombExplosion.GetObject();
            explosion.transform.position = transform.position;

            SoundManager.instance.PlaySound("ColorBomb");
        }

        /// <summary>
        /// Updates the specified game state when this tile explodes.
        /// </summary>
        /// <param name="state">The game state.</param>
        public override void UpdateGameState(GameState state)
        {
        }
    }
}