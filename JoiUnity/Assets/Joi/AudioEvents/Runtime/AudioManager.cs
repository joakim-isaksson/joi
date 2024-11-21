using UnityEngine;

namespace Joi.AudioEvents
{
	public class AudioManager : MonoBehaviour
	{
		private static AudioManager _instance;

		private AudioPlayerPool _audioPlayerPool;
		
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void CreateInstance()
		{
			if (_instance != null)
			{
				return;
			}

			var settings = Resources.Load<AudioManagerSettings>(nameof(AudioManagerSettings));
			if (settings == null)
			{
				return;
			}
			
			var gameObject = new GameObject(nameof(AudioManager));
			var audioManager = gameObject.AddComponent<AudioManager>();
			audioManager.Initialize(settings);
			
			DontDestroyOnLoad(audioManager);
			
			_instance = audioManager;
		}

		private void Initialize(AudioManagerSettings settings)
		{
			_audioPlayerPool = gameObject.AddComponent<AudioPlayerPool>();
			_audioPlayerPool.Initialize(settings);
		}
		
		public static void Play(AudioEvent audioEvent, Transform parent = null)
		{
			if (_instance == null)
			{
				Debug.LogWarning("Playing audio failed: AudioManager not initialized");
				return;
			}
			
			_instance.PlayAudioEvent(audioEvent, parent);
		}
		
		public void PlayAudioEvent(AudioEvent audioEvent, Transform parent = null)
		{
			_audioPlayerPool.Get(parent).Play(audioEvent);
		}
	}
}