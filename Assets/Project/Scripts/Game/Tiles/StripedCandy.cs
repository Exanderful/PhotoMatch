using System.Collections.Generic;

using UnityEngine;

using GEM.Core;

namespace GEM.Game.Common
{
    public enum StripeDirection
    {
        Horizontal,
        Vertical
    }

    /// <summary>
    /// The class used for striped candies.
    /// </summary>
    public class StripedCandy : Candy
    {
        public StripeDirection direction;

        private readonly List<GameObject> cachedTiles = new List<GameObject>();

        /// <summary>
        /// Returns a list containing all the tiles destroyed when this tile explodes.
        /// </summary>
        /// <returns>A list containing all the tiles destroyed when this tile explodes.</returns>
        public override List<GameObject> Explode()
        {
            var tiles = new List<GameObject>();

            if (direction == StripeDirection.Horizontal)
            {
                for (var i = 0; i < board.level.width; i++)
                {
                    var tile = board.GetTile(i, y);
                    tiles.Add(tile);
                }
            }
            else
            {
                for (var j = 0; j < board.level.height; j++)
                {
                    var tile = board.GetTile(x, j);
                    tiles.Add(tile);
                }
            }

            cachedTiles.Clear();
            foreach (var tile in tiles)
            {
                if (tile != null)
                {
                    cachedTiles.Add(tile);
                }
            }

            return tiles;
        }

        /// <summary>
        /// Shows the visual effects associated to the explosion of this tile.
        /// </summary>
        /// <param name="pool">The pool to use for the visual effects.</param>
        public override void ShowExplosionFx(FxPool pool)
        {
            base.ShowExplosionFx(pool);

            foreach (var tile in cachedTiles)
            {
                if (tile != null)
                {
                    var stripes = pool.GetStripedCandyExplosionPool(direction).GetObject();
                    stripes.transform.position = tile.transform.position;
                }
            }

            SoundManager.instance.PlaySound("LineVerticalHorizontal");
        }
    }
}