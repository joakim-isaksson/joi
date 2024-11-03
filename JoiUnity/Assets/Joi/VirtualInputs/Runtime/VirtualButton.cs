using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Joi.VirtualInputs
{
	public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private static readonly Dictionary<string, bool> Buttons = new ();

		[SerializeField] private string _buttonName;

		private void OnDisable()
		{
			Buttons[_buttonName] = false;
		}
	
		public void OnPointerDown(PointerEventData eventData)
		{
			Buttons[_buttonName] = true;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Buttons[_buttonName] = false;
		}

		public static bool GetButton(string buttonName)
		{
			return Buttons.GetValueOrDefault(buttonName, false);
		}
	}
}