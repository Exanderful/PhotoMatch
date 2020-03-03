using System.Collections;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GEM.Core;

namespace GEM.Game.Popups
{
    /// <summary>
    /// This class contains the logic associated to the level regeneration popup that appears when there are
    /// no possible matches on a level.
    /// </summary>
	public class RegenLevelPopup : Popup
    {
	    [SerializeField]
	    private Text text;

	    /// <summary>
	    /// Unity's Awake method.
	    /// </summary>
	    protected override void Awake()
	    {
		    base.Awake();
		    Assert.IsNotNull(text);
	    }

	    /// <summary>
        /// Unity's Start method.
        /// </summary>
        protected override void Start()
        {
            base.Start();
	        StartCoroutine(AnimateText());
            StartCoroutine(AutoKill());
        }

	    /// <summary>
	    /// This coroutine animates the popup's text.
	    /// </summary>
	    /// <returns>The coroutine.</returns>
	    private IEnumerator AnimateText()
	    {
		    for (var i = 0; i < 100; i++)
		    {
			    text.text = "Regenerating level.";
			    yield return new WaitForSeconds(0.4f);
			    text.text = "Regenerating level..";
			    yield return new WaitForSeconds(0.4f);
			    text.text = "Regenerating level...";
			    yield return new WaitForSeconds(0.4f);
		    }
	    }

        /// <summary>
        /// This coroutine automatically closes the popup after some time has passed.
        /// </summary>
        /// <returns>The coroutine.</returns>
        private IEnumerator AutoKill()
        {
            yield return new WaitForSeconds(3.0f);
            Close();
        }
	}
}