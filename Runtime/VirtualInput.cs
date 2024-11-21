using UnityEngine;

namespace Joi.VirtualInputs
{
	public static class VirtualInput
	{
		/// <summary>
		///   <para>Returns true while the virtual button identified by buttonName is held down.</para>
		/// </summary>
		/// <param name="buttonName">The name of the button such as Jump.</param>
		/// <returns>
		///   <para>True when an axis has been pressed and not released.</para>
		/// </returns>
		public static bool GetButton(string buttonName)
		{
#if UNITY_EDITOR
			return VirtualButton.GetButton(buttonName) || Input.GetButton(buttonName);
#else
		return VirtualButton.GetButton(buttonName);
#endif
		}

		/// <summary>
		///   <para>Returns the value of the virtual axis identified by axisName with no smoothing filtering applied.</para>
		/// </summary>
		/// <param name="axisName"></param>
		public static float GetAxisRaw(string axisName)
		{
#if UNITY_EDITOR
			return VirtualJoystick.GetAxisRaw(axisName) != 0 ? VirtualJoystick.GetAxisRaw(axisName) : Input.GetAxisRaw(axisName);
#else
		return VirtualJoystick.GetAxisRaw(axisName);
#endif
		}
	}
}