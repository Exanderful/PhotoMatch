using UnityEngine;

namespace GEM.Game.Common
{
	/// <summary>
	/// The class that represents the lollipop booster.
	/// </summary>
	public class LollipopBooster : Booster
	{
        /// <summary>
        /// Resolves this booster.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tile">The tile in which to apply the booster.</param>
		public override void Resolve(GameBoard board, GameObject tile)
		{
			board.ExplodeTile(tile);
		}
	}
}