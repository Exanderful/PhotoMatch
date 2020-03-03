using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

using GEM.Core;

namespace GEM.Game.Common
{
    /// <summary>
    /// This class stores the pools of the tiles used in the game.
    /// </summary>
    public class TilePool : MonoBehaviour
    {
        public ObjectPool photo1Pool;
        public ObjectPool photo2Pool;
        public ObjectPool photo3Pool;
        public ObjectPool photo4Pool;
        public ObjectPool photo5Pool;
        public ObjectPool photo6Pool;

        public ObjectPool photo1HorizontalStripedPool;
        public ObjectPool photo2HorizontalStripedPool;
        public ObjectPool photo3HorizontalStripedPool;
        public ObjectPool photo4HorizontalStripedPool;
        public ObjectPool photo5HorizontalStripedPool;
        public ObjectPool photo6HorizontalStripedPool;

        public ObjectPool photo1VerticalStripedPool;
        public ObjectPool photo2VerticalStripedPool;
        public ObjectPool photo3VerticalStripedPool;
        public ObjectPool photo4VerticalStripedPool;
        public ObjectPool photo5VerticalStripedPool;
        public ObjectPool photo6VerticalStripedPool;

        public ObjectPool photo1WrappedPool;
        public ObjectPool photo2WrappedPool;
        public ObjectPool photo3WrappedPool;
        public ObjectPool photo4WrappedPool;
        public ObjectPool photo5WrappedPool;
        public ObjectPool photo6WrappedPool;

        public ObjectPool photoBombPool;

        public ObjectPool honeyPool;
        public ObjectPool icePool;
        public ObjectPool syrup1Pool;
        public ObjectPool syrup2Pool;

        public ObjectPool marshmallowPool;
        public ObjectPool chocolatePool;
        public ObjectPool unbreakablePool;

        public ObjectPool cherryPool;
        public ObjectPool watermelonPool;

        public ObjectPool lightBgTilePool;
        public ObjectPool darkBgTilePool;

        private readonly List<ObjectPool> photos = new List<ObjectPool>();
        private readonly List<ObjectPool> horizontalStripedPhotos = new List<ObjectPool>();
        private readonly List<ObjectPool> verticalStripedPhotos = new List<ObjectPool>();
        private readonly List<ObjectPool> wrappedPhotos = new List<ObjectPool>();

        private readonly List<ObjectPool> specialBlocks = new List<ObjectPool>();

        private readonly List<ObjectPool> collectables = new List<ObjectPool>();

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Assert.IsNotNull(photo1Pool);
            Assert.IsNotNull(photo2Pool);
            Assert.IsNotNull(photo3Pool);
            Assert.IsNotNull(photo4Pool);
            Assert.IsNotNull(photo5Pool);
            Assert.IsNotNull(photo6Pool);

            Assert.IsNotNull(photo1HorizontalStripedPool);
            Assert.IsNotNull(photo2HorizontalStripedPool);
            Assert.IsNotNull(photo3HorizontalStripedPool);
            Assert.IsNotNull(photo4HorizontalStripedPool);
            Assert.IsNotNull(photo5HorizontalStripedPool);
            Assert.IsNotNull(photo6HorizontalStripedPool);

            Assert.IsNotNull(photo1VerticalStripedPool);
            Assert.IsNotNull(photo2VerticalStripedPool);
            Assert.IsNotNull(photo3VerticalStripedPool);
            Assert.IsNotNull(photo4VerticalStripedPool);
            Assert.IsNotNull(photo5VerticalStripedPool);
            Assert.IsNotNull(photo6VerticalStripedPool);

            Assert.IsNotNull(photo1WrappedPool);
            Assert.IsNotNull(photo2WrappedPool);
            Assert.IsNotNull(photo3WrappedPool);
            Assert.IsNotNull(photo4WrappedPool);
            Assert.IsNotNull(photo5WrappedPool);
            Assert.IsNotNull(photo6WrappedPool);

            Assert.IsNotNull(photoBombPool);

            Assert.IsNotNull(honeyPool);
            Assert.IsNotNull(icePool);
            Assert.IsNotNull(syrup1Pool);
            Assert.IsNotNull(syrup2Pool);

            Assert.IsNotNull(marshmallowPool);
            Assert.IsNotNull(chocolatePool);
            Assert.IsNotNull(unbreakablePool);

            Assert.IsNotNull(cherryPool);
            Assert.IsNotNull(watermelonPool);

            Assert.IsNotNull(lightBgTilePool);
            Assert.IsNotNull(darkBgTilePool);

            photos.Add(photo1Pool);
            photos.Add(photo2Pool);
            photos.Add(photo3Pool);
            photos.Add(photo4Pool);
            photos.Add(photo5Pool);
            photos.Add(photo6Pool);

            horizontalStripedPhotos.Add(photo1HorizontalStripedPool);
            horizontalStripedPhotos.Add(photo2HorizontalStripedPool);
            horizontalStripedPhotos.Add(photo3HorizontalStripedPool);
            horizontalStripedPhotos.Add(photo4HorizontalStripedPool);
            horizontalStripedPhotos.Add(photo5HorizontalStripedPool);
            horizontalStripedPhotos.Add(photo6HorizontalStripedPool);

            verticalStripedPhotos.Add(photo1VerticalStripedPool);
            verticalStripedPhotos.Add(photo2VerticalStripedPool);
            verticalStripedPhotos.Add(photo3VerticalStripedPool);
            verticalStripedPhotos.Add(photo4VerticalStripedPool);
            verticalStripedPhotos.Add(photo5VerticalStripedPool);
            verticalStripedPhotos.Add(photo6VerticalStripedPool);

            wrappedPhotos.Add(photo1WrappedPool);
            wrappedPhotos.Add(photo2WrappedPool);
            wrappedPhotos.Add(photo3WrappedPool);
            wrappedPhotos.Add(photo4WrappedPool);
            wrappedPhotos.Add(photo5WrappedPool);
            wrappedPhotos.Add(photo6WrappedPool);

            specialBlocks.Add(marshmallowPool);
            specialBlocks.Add(chocolatePool);
            specialBlocks.Add(unbreakablePool);

            collectables.Add(cherryPool);
            collectables.Add(watermelonPool);
        }

        /// <summary>
        /// Returns the pool of the specified candy color.
        /// </summary>
        /// <param name="color">The candy color.</param>
        /// <returns>The pool of the specified candy color.</returns>
        public ObjectPool GetCandyPool(CandyColor color)
        {
            return photos[(int) color];
        }

        /// <summary>
        /// Returns the pool of the specified striped candy.
        /// </summary>
        /// <param name="direction">The direction of the striped candy.</param>
        /// <param name="color">The color of the striped candy.</param>
        /// <returns>The pool of the specified striped candy.</returns>
        public ObjectPool GetStripedCandyPool(StripeDirection direction, CandyColor color)
        {
            switch (direction)
            {
                case StripeDirection.Horizontal:
                    return horizontalStripedPhotos[(int) color];

                default:
                    return verticalStripedPhotos[(int) color];

            }
        }

        /// <summary>
        /// Returns the pool of the specified wrapped candy.
        /// </summary>
        /// <param name="color">The color of the wrapped candy.</param>
        /// <returns>The pool of the specified wrapped candy.</returns>
        public ObjectPool GetWrappedCandyPool(CandyColor color)
        {
            return wrappedPhotos[(int) color];
        }

        /// <summary>
        /// Returns the pool of the specified block.
        /// </summary>
        /// <param name="block">The block.</param>
        /// <returns>The pool of the specified block.</returns>
        public ObjectPool GetSpecialBlockPool(SpecialBlockType block)
        {
            return specialBlocks[(int) block];
        }

        /// <summary>
        /// Returns the pool of the specified collectable.
        /// </summary>
        /// <param name="collectable">The collectable.</param>
        /// <returns>The pool of the specified collectable.</returns>
        public ObjectPool GetCollectablePool(CollectableType collectable)
        {
            return collectables[(int) collectable];
        }
    }
}