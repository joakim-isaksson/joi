using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Joi.VirtualInputs
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private static readonly Dictionary<string, float> Axis = new();

        [SerializeField] private string _horizontalAxisName;
        [SerializeField] private string _verticalAxisName;

        [SerializeField] private RectTransform _background;
        [SerializeField] private RectTransform _handle;

        [SerializeField] [Range(0f, 1f)] private float _handleLimit = 1f;
        [SerializeField] private bool _snapping = true;

        private Vector2 _backgroundDefaultPosition;

        private void Start()
        {
            _backgroundDefaultPosition = _background.localPosition;
        }

        private void OnDisable()
        {
            ResetJoystick();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_snapping && RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
            {
                _background.localPosition = localPoint;
            }

            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_background, eventData.position, eventData.pressEventCamera, out var localPos))
            {
                var axis = localPos / (_background.sizeDelta / 2);

                if (axis.magnitude > 1.0f)
                {
                    axis = axis.normalized;
                }

                _handle.localPosition = new Vector2(
                    axis.x * (_background.sizeDelta.x / 2) * _handleLimit,
                    axis.y * (_background.sizeDelta.y / 2) * _handleLimit
                );

                Axis[_horizontalAxisName] = axis.x;
                Axis[_verticalAxisName] = axis.y;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ResetJoystick();
        }

        private void ResetJoystick()
        {
            Axis[_horizontalAxisName] = 0;
            Axis[_verticalAxisName] = 0;

            _handle.localPosition = Vector2.zero;
            _background.localPosition = _backgroundDefaultPosition;
        }

        public static float GetAxisRaw(string axisName)
        {
            return Axis.GetValueOrDefault(axisName, 0);
        }
    }
}