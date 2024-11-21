using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Joi.AudioEvents
{
	public class AudioPlayer : MonoBehaviour
	{
		public Action<AudioPlayer> OnPlayingEnded;
		
		[SerializeField] private AudioSource _audioSource;
		
		private Coroutine _playing;

		public void Play(AudioEvent audioEvent)
		{
			if (_playing != null)
			{
				StopCoroutine(_playing);
			}
			
			_audioSource.outputAudioMixerGroup = audioEvent.AudioMixerGroup;
			_audioSource.volume = audioEvent.Volume.Evaluate(Random.value);
			_audioSource.pitch = audioEvent.Pitch.Evaluate(Random.value);
			_audioSource.spatialBlend = audioEvent.SpatialBlend;
			_audioSource.priority = audioEvent.Priority;
			
			_audioSource.Play();
			
			_playing = StartCoroutine(PlayingCoroutine(audioEvent));
		}

		private IEnumerator PlayingCoroutine(AudioEvent audioEvent)
		{
			do
			{
				_audioSource.Stop();
				_audioSource.clip = audioEvent.GetNextClip();
				_audioSource.Play();
				
				yield return new WaitForSeconds(_audioSource.clip.length);
				
			} while (audioEvent.IsLooping);
			
			OnPlayingEnded?.Invoke(this);
		}

		private void OnDisable()
		{
			OnPlayingEnded?.Invoke(this);
		}
	}
}