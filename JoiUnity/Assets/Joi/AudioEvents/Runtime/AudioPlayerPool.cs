using System.Collections.Generic;
using UnityEngine;

namespace Joi.AudioEvents
{
	public class AudioPlayerPool : MonoBehaviour
	{
		private AudioPlayer _audioPlayerPrefab;

		private readonly Stack<AudioPlayer> _audioPlayers = new();
		private readonly Stack<AudioPlayer> _pendingReturn = new();

		public void Initialize(AudioManagerSettings settings)
		{
			_audioPlayerPrefab = settings.AudioPlayerPrefab;
			
			for (var i = 0; i < settings.AudioPlayerPoolSize; i++)
			{
				var newAudioPlayer = Instantiate(_audioPlayerPrefab, transform);
				newAudioPlayer.gameObject.SetActive(false);
				_audioPlayers.Push(newAudioPlayer);
			}
		}
		
		public AudioPlayer Get(Transform parent = null)
		{
			if (!_audioPlayers.TryPop(out var audioPlayer))
			{
				audioPlayer = Instantiate(_audioPlayerPrefab, transform);
			}
			
			if (parent != null)
			{
				audioPlayer.transform.SetParent(parent);
				audioPlayer.transform.localPosition = Vector3.zero;
			}
			
			audioPlayer.gameObject.SetActive(true);
			audioPlayer.OnPlayingEnded += OnPlayingEnded;
			
			return audioPlayer;
		}

		private void OnPlayingEnded(AudioPlayer audioPlayer)
		{
			audioPlayer.OnPlayingEnded -= OnPlayingEnded;
			_pendingReturn.Push(audioPlayer);
		}

		private void LateUpdate()
		{
			while (_pendingReturn.Count > 0)
			{
				var audioPlayer = _pendingReturn.Pop();
				audioPlayer.gameObject.SetActive(false);
				audioPlayer.transform.SetParent(transform);
				audioPlayer.transform.localPosition = Vector3.zero;
				
				_audioPlayers.Push(audioPlayer);
			}
		}
	}
}