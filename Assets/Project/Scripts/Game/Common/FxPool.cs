using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

using GEM.Core;

namespace GEM.Game.Common
{
    /// <summary>
    /// This class stores the pools of the visual effects used in the game.
    /// </summary>
    public class FxPool : MonoBehaviour
    {
        public ObjectPool spawnParticles;

        public ObjectPool photo1Explosion;
        public ObjectPool photo2Explosion;
        public ObjectPool photo3Explosion;
        public ObjectPool photo4Explosion;
        public ObjectPool photo5Explosion;
        public ObjectPool photo6Explosion;

        public ObjectPool horizontalStripedPhotoExplosion;
        public ObjectPool verticalStripedPhotoExplosion;

        public ObjectPool wrappedPhotoExplosion;

        public ObjectPool photoBombExplosion;

        public ObjectPool honeyExplosion;
        public ObjectPool iceExplosion;
        public ObjectPool syrupExplosion;

        public ObjectPool marshmallowExplosion;
        public ObjectPool chocolateExplosion;

        public ObjectPool collectableExplosion;

        public ObjectPool complimentTextPool;

        private readonly List<ObjectPool> candyExplosions = new List<ObjectPool>();
        private readonly List<ObjectPool> elementExplosions = new List<ObjectPool>();
        private readonly List<ObjectPool> specialBlockExplosions = new List<ObjectPool>();

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Assert.IsNotNull(spawnParticles);

            Assert.IsNotNull(photo1Explosion);
            Assert.IsNotNull(photo2Explosion);
            Assert.IsNotNull(photo3Explosion);
            Assert.IsNotNull(photo4Explosion);
            Assert.IsNotNull(photo5Explosion);
            Assert.IsNotNull(photo6Explosion);
            Assert.IsNotNull(horizontalStripedPhotoExplosion);
            Assert.IsNotNull(verticalStripedPhotoExplosion);
            Assert.IsNotNull(wrappedPhotoExplosion);
            Assert.IsNotNull(photoBombExplosion);
            Assert.IsNotNull(honeyExplosion);
            Assert.IsNotNull(iceExplosion);
            Assert.IsNotNull(marshmallowExplosion);
            Assert.IsNotNull(chocolateExplosion);
            Assert.IsNotNull(collectableExplosion);

            Assert.IsNotNull(complimentTextPool);

            candyExplosions.Add(photo1Explosion);
            candyExplosions.Add(photo2Explosion);
            candyExplosions.Add(photo3Explosion);
            candyExplosions.Add(photo4Explosion);
            candyExplosions.Add(photo5Explosion);
            candyExplosions.Add(photo6Explosion);

            elementExplosions.Add(null);
            elementExplosions.Add(honeyExplosion);
            elementExplosions.Add(iceExplosion);
            elementExplosions.Add(syrupExplosion);
            elementExplosions.Add(syrupExplosion);

            specialBlockExplosions.Add(marshmallowExplosion);
            specialBlockExplosions.Add(chocolateExplosion);
            specialBlockExplosions.Add(null);
        }

        /// <summary>
        /// Returns the explosion pool of the specified candy color.
        /// </summary>
        /// <param name="color">The candy color.</param>
        /// <returns>The explosion pool of the specified candy color.</returns>
        public ObjectPool GetCandyExplosionPool(CandyColor color)
        {
            return candyExplosions[(int) color];
        }

        /// <summary>
        /// Returns the explosion pool of the specified striped candy.
        /// </summary>
        /// <param name="direction">The direction of the striped candy.</param>
        /// <returns>The explosion pool of the specified striped candy.</returns>
        public ObjectPool GetStripedCandyExplosionPool(StripeDirection direction)
        {
            switch (direction)
            {
                case StripeDirection.Horizontal:
                    return horizontalStripedPhotoExplosion;

                default:
                    return verticalStripedPhotoExplosion;
            }
        }

        /// <summary>
        /// Returns the explosion pool of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The explosion pool of the specified element.</returns>
        public ObjectPool GetElementExplosion(ElementType element)
        {
            return elementExplosions[(int) element];
        }

        /// <summary>
        /// Returns the explosion pool of the specified block.
        /// </summary>
        /// <param name="block">The block.</param>
        /// <returns>The explosion pool of the specified block.</returns>
        public ObjectPool GetSpecialBlockExplosion(SpecialBlockType block)
        {
            return specialBlockExplosions[(int) block];
        }
    }
}