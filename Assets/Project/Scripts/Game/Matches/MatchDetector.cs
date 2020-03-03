using System.Collections.Generic;

namespace GEM.Game.Common
{
	/// <summary>
	/// The base class of match detectors.
	/// </summary>
	public abstract class MatchDetector
	{
		/// <summary>
		/// Returns the list of detected matches.
		/// </summary>
		/// <param name="board">The game board.</param>
		/// <returns>The list of detected matches.</returns>
		public abstract List<Match> DetectMatches(GameBoard board);
	}
}