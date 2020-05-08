using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;

using GEM.Game.Common;
using GEM.Game.Popups;
using GEM.Game.Scenes;
#endif


namespace GEM.Game.UI
{
	/// <summary>
	/// The rewarded advertisement button that is present in the level scene.
	/// </summary>
	public class RewardedAdButton : MonoBehaviour
	{
		/// <summary>
		/// Shows the rewarded advertisement.
		/// </summary>
		public void ShowRewardedAd()
		{
			#if UNITY_ADS
			if (Advertisement.IsReady("rewardedVideo"))
			{
				var options = new ShowOptions { resultCallback = HandleShowResult };
				Advertisement.Show("rewardedVideo", options);
			}
			#endif
		}

#if UNITY_ADS
		/// <summary>
		/// Handles the result of showing the rewarded advertisement.
		/// </summary>
		/// <param name="result">The result of showing the rewarded advertisement.</param>
		private void HandleShowResult(ShowResult result)
		{
			switch (result)
			{
				case ShowResult.Finished:
					var gameManager = PuzzleMatchManager.instance;
					var rewardCoins = gameManager.gameConfig.rewardedAdCoins;
            		gameManager.coinsSystem.BuyCoins(rewardCoins);
					var levelScene = GameObject.Find("LevelScene");
					if (levelScene != null)
					{
						levelScene.GetComponent<LevelScene>().OpenPopup<AlertPopup>("Popups/AlertPopup", popup =>
						{
                			popup.SetTitle(LocalizationManager.instance.GetLocalizedValue("_reward"));
                			popup.SetText(string.Format(LocalizationManager.instance.GetLocalizedValue("_reward_text"), rewardCoins));
            			}, false);
					}
					break;

				default:
					break;
			}
		}
#endif
	}
}