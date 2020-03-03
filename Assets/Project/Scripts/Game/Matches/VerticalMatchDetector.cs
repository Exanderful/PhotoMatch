using System.Collections.Generic;

namespace GEM.Game.Common
{
    /// <summary>
    /// Match detector that detects vertical matches.
    /// </summary>
	public class VerticalMatchDetector : MatchDetector
	{
		/// <summary>
		/// Returns the list of detected matches.
		/// </summary>
		/// <param name="board">The game board.</param>
		/// <returns>The list of detected matches.</returns>
		public override List<Match> DetectMatches(GameBoard board)
		{
            var matches = new List<Match>();

            for (var i = 0; i < board.level.width; i++)
            {
                for (var j = 0; j < board.level.height - 2;)
                {
                    var tile = board.GetTile(i, j);
                    if (tile != null && tile.GetComponent<Candy>() != null)
                    {
                        var color = tile.GetComponent<Candy>().color;
                        if (board.GetTile(i, j + 1) != null && board.GetTile(i, j + 1).GetComponent<Candy>() != null &&
                            board.GetTile(i, j + 1).GetComponent<Candy>().color == color &&
                            board.GetTile(i, j + 2) != null && board.GetTile(i, j + 2).GetComponent<Candy>() != null &&
                            board.GetTile(i, j + 2).GetComponent<Candy>().color == color)
                        {
                            var match = new Match();
                            match.type = MatchType.Vertical;
                            do
                            {
                                match.AddTile(board.GetTile(i, j));
                                j += 1;
                            } while (j < board.level.height && board.GetTile(i, j) != null &&
                                     board.GetTile(i, j).GetComponent<Candy>() != null &&
                                     board.GetTile(i, j).GetComponent<Candy>().color == color);

                            matches.Add(match);
                            continue;
                        }
                    }

                    j += 1;
                }
            }

            return matches;
		}
	}
}