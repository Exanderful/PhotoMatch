using UnityEngine;
using UnityEngine.Assertions;

namespace GEM.Game.UI
{
	/// <summary>
	/// This class manages the girl displayed during a game at the top bar of the UI.
	/// </summary>
	public class Girl : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem particles;

		/// <summary>
		/// Unity's Awake method.
		/// </summary>
		private void Awake()
		{
			Assert.IsNotNull(particles);
		}

		/// <summary>
		/// Plays the "happy" particle system.
		/// </summary>
		public void PlayParticles()
		{
			particles.Play();
		}
	}
}