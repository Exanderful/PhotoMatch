using System.Collections.Generic;
using System;

using UnityEngine;

using GEM.Core;

namespace GEM.Game.Common
{

    /// <summary>
    /// The base class of candies.
    /// </summary>
    public class Candy : Tile
    {
        public CandyColor color;
        private Sprite photoSprite;

        /// <summary>
        /// Returns a list containing all the tiles destroyed when this tile explodes.
        /// </summary>
        /// <returns>A list containing all the tiles destroyed when this tile explodes.</returns>
        public override List<GameObject> Explode()
        {
            if (gameObject.activeSelf && GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().SetTrigger("Kill");
            }

            return new List<GameObject> {gameObject};
        }

        /// <summary>
        /// Shows the visual effects associated to the explosion of this tile.
        /// </summary>
        /// <param name="pool">The pool to use for the visual effects.</param>
        public override void ShowExplosionFx(FxPool pool)
        {
            var particles = pool.GetCandyExplosionPool(color).GetObject();
            particles.transform.position = transform.position;
        }

        /// <summary>
        /// Updates the specified game state when this tile explodes.
        /// </summary>
        /// <param name="state">The game state.</param>
        public override void UpdateGameState(GameState state)
        {
            state.AddCandy(color);
        }

        private void Start()
        {
            if (color == CandyColor.Blue)
            {
                photoSprite = DownloadManager.instance.GetImageById(1);
            }
            if (color == CandyColor.Green)
            {
                photoSprite = DownloadManager.instance.GetImageById(2);
            }
            if (color == CandyColor.Orange)
            {
                photoSprite = DownloadManager.instance.GetImageById(3);
            }
            if (color == CandyColor.Purple)
            {
                photoSprite = DownloadManager.instance.GetImageById(4);
            }
            if (color == CandyColor.Red)
            {
                photoSprite = DownloadManager.instance.GetImageById(5);
            }
            if (color == CandyColor.Yellow)
            {
                photoSprite = DownloadManager.instance.GetImageById(6);
            }
            GetComponent<SpriteRenderer>().sprite = photoSprite;
        }
    }
}