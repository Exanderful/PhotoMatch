using UnityEngine;
using UnityEngine.UI;

using GEM.Game.Common;

namespace GEM.Game.UI
{
	/// <summary>
	/// This class loads the booster data into the in-game booster buttons when the game starts.
	/// </summary>
	public class BoosterBar : MonoBehaviour
	{
		[SerializeField]
		private BuyBoosterButton button1;
		public GameObject lockedButton1;

		[SerializeField]
		private BuyBoosterButton button2;
		public GameObject lockedButton2;

		[SerializeField]
		private BuyBoosterButton button3;
		public GameObject lockedButton3;

		[SerializeField]
		private BuyBoosterButton button4;
		public GameObject lockedButton4;

		/// <summary>
		/// Sets the data of the in-game booster buttons.
		/// </summary>
		/// <param name="level">The current level.</param>
		public void SetData(Level level)
		{
			if (level.availableBoosters[BoosterType.Lollipop])
			{
				button1.UpdateAmount(PlayerPrefs.GetInt("num_boosters_0"));
				lockedButton1.gameObject.SetActive(false);
			}
			else
			{
				button1.gameObject.SetActive(false);
			}

			if (level.availableBoosters[BoosterType.Bomb])
			{
				button2.UpdateAmount(PlayerPrefs.GetInt("num_boosters_1"));
				lockedButton2.gameObject.SetActive(false);
			}
			else
			{
				button2.gameObject.SetActive(false);
			}

			if (level.availableBoosters[BoosterType.Switch])
			{
				button3.UpdateAmount(PlayerPrefs.GetInt("num_boosters_2"));
				lockedButton3.gameObject.SetActive(false);
			}
			else
			{
				button3.gameObject.SetActive(false);
			}

			if (level.availableBoosters[BoosterType.ColorBomb])
			{
				button4.UpdateAmount(PlayerPrefs.GetInt("num_boosters_3"));
				lockedButton4.gameObject.SetActive(false);
			}
			else
			{
				button4.gameObject.SetActive(false);
			}
		}
	}
}