using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Joi.AudioEvents
{
	[CreateAssetMenu(menuName = "Joi/Audio Event", fileName = "AudioEvent")]
	public class AudioEvent : ScriptableObject
	{
		private enum SequenceType
		{
			RandomExcludingPrevious,
			Random,
			InOrderFromFirstToLast
		}

		[SerializeField]
		private AudioMixerGroup _audioMixerGroup;
		
		[SerializeField]
		private AudioClip[] _audioClips = new AudioClip[1];
		
		[SerializeField]
		private SequenceType _sequence;

		[SerializeField]
		private bool _looping;
		
		[SerializeField]
		private AnimationCurve _volume = AnimationCurve.Constant(0f, 1f, 0f);
		
		[SerializeField]
		private AnimationCurve _pitch = AnimationCurve.Constant(0f, 1f, 0f);
		
		[SerializeField]
		[Tooltip("0 (2D) - 1 (3D)")]
		[Range(0f, 1f)]
		private float _spatialBlend = 1f;

		[SerializeField]
		[Tooltip("1 highest priority, 5 lowest priority")]
		[Range(1, 5)]
		private int _priority = 3;

		public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;
		public bool IsLooping => _looping;
		public AnimationCurve Volume => _volume;
		public AnimationCurve Pitch => _pitch;
		public float SpatialBlend => _spatialBlend;
		public bool IsSpatial => _spatialBlend > 0;
		public int Priority => (_priority - 1) * 64;

		private int _previousClipIndex;

		public void Play()
		{
			AudioManager.Play(this);
		}

		public AudioClip GetNextClip()
		{
			if (_audioClips.Length == 0)
			{
				return null;
			}

			if (_audioClips.Length == 1)
			{
				return _audioClips[0];
			}

			var nextClipIndex = 0;
			switch (_sequence)
			{
				case SequenceType.Random:
					nextClipIndex = Random.Range(0, _audioClips.Length);
					break;
				case SequenceType.RandomExcludingPrevious:
					nextClipIndex = (_previousClipIndex + Random.Range(1, _audioClips.Length)) % _audioClips.Length;
					break;
				case SequenceType.InOrderFromFirstToLast:
					nextClipIndex = (_previousClipIndex + 1) % _audioClips.Length;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_previousClipIndex = nextClipIndex;

			return _audioClips[nextClipIndex];
		}
	}
}