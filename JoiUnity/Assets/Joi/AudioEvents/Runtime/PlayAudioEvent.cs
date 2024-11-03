using UnityEngine;

namespace Joi.AudioEvents
{
	public class PlayAudioEvent : MonoBehaviour
	{
		private enum TriggerBehaviour
		{
			None,
			OnAwake,
			OnStart,
			OnEnabled,
			OnDisable,
			OnDestroy,
		}

		[SerializeField] private TriggerBehaviour _trigger;
		[SerializeField] private AudioEvent _audioEvent;

		private void Awake()
		{
			if (_trigger == TriggerBehaviour.OnAwake)
			{
				Play();
			}
		}

		private void Start()
		{
			if (_trigger == TriggerBehaviour.OnStart)
			{
				Play();
			}
		}

		private void OnEnable()
		{
			if (_trigger == TriggerBehaviour.OnEnabled)
			{
				Play();
			}
		}

		private void OnDisable()
		{
			if (_trigger == TriggerBehaviour.OnDisable)
			{
				Play();
			}
		}

		private void OnDestroy()
		{
			if (_trigger == TriggerBehaviour.OnDestroy)
			{
				Play();
			}
		}

		public void Play()
		{
			PlayEvent(_audioEvent);
		}

		public void PlayEvent(AudioEvent audioEvent)
		{
			if (audioEvent.IsSpatial)
			{
				AudioManager.Play(audioEvent, transform);
			}
			else
			{
				AudioManager.Play(audioEvent);
			}
		}
	}
}