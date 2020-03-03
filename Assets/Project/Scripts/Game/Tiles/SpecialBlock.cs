using System.Collections.Generic;

using UnityEngine;

namespace GEM.Game.Common
{
    /// <summary>
    /// The base class of the special blocks.
    /// </summary>
    public class SpecialBlock : Tile
    {
        public SpecialBlockType type;

        /// <summary>
        /// Returns a list containing all the tiles destroyed when this tile explodes.
        /// </summary>
        /// <returns>A list containing all the tiles destroyed when this tile explodes.</returns>
        public override List<GameObject> Explode()
        {
            return new List<GameObject>();
        }

        /// <summary>
        /// Shows the visual effects associated to the explosion of this tile.
        /// </summary>
        /// <param name="pool">The pool to use for the visual effects.</param>
        public override void ShowExplosionFx(FxPool pool)
        {
            var fxPool = pool.GetSpecialBlockExplosion(type);
            if (fxPool != null)
            {
                var fx = fxPool.GetObject();
                fx.transform.position = gameObject.transform.position;
            }
        }

        /// <summary>
        /// Updates the specified game state when this tile explodes.
        /// </summary>
        /// <param name="state">The game state.</param>
        public override void UpdateGameState(GameState state)
        {
            state.AddSpecialBlock(type);
        }
    }
}