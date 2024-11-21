using UnityEngine;
using UnityEngine.Audio;

namespace Joi.AudioEvents
{
	public static class AudioMixerGroupExtensions
	{
		private const string VolumeParamSuffix = ".Volume";

		public static void SetVolume(this AudioMixerGroup audioMixerGroup, float volume)
		{
			audioMixerGroup.audioMixer.SetFloat(audioMixerGroup.name + VolumeParamSuffix, Mathf.Lerp(-80f, 0f, volume));
		}

		public static float GetVolume(this AudioMixerGroup audioMixerGroup)
		{
			audioMixerGroup.audioMixer.GetFloat(audioMixerGroup.name + VolumeParamSuffix, out var volume);
			
			return Mathf.InverseLerp(-80f, 0f, volume);
		}

		public static void SaveVolume(this AudioMixerGroup audioMixerGroup)
		{
			PlayerPrefs.SetFloat(audioMixerGroup.audioMixer.name + audioMixerGroup.name + VolumeParamSuffix, audioMixerGroup.GetVolume());
		}

		public static void LoadVolume(this AudioMixerGroup audioMixerGroup)
		{
			audioMixerGroup.SetVolume(PlayerPrefs.GetFloat(audioMixerGroup.audioMixer.name + audioMixerGroup.name + VolumeParamSuffix, 1f));
		}
	}
}