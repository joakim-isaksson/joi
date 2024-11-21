using UnityEngine;

namespace Joi.AudioEvents
{
	[CreateAssetMenu(menuName = "Joi/Audio Manager Settings", fileName = nameof(AudioManagerSettings))]
	public class AudioManagerSettings : ScriptableObject
	{
		[Header("Audio Player Pool")]
		[SerializeField] private AudioPlayer _audioPlayerPrefab;
		[SerializeField] private int _audioPlayerPoolSize;

		public AudioPlayer AudioPlayerPrefab => _audioPlayerPrefab;
		public int AudioPlayerPoolSize => _audioPlayerPoolSize;
	}
}