using PixupGames.Infrastracture.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Core
{
    public class MainCamera : MonoBehaviour, ICamera
    {
        [SerializeField] private float _forwardOffsetMultiplier = 10f;
        [SerializeField] [Range(0, 1)] private float _smooth = 0.5f;

        private Vector3 _oldOffset;
        private Vector3 _offset;
        private ICameraTarget _target;

        private void FixedUpdate()
        {
            Follow();         
        }

        public void SetTarget(ICameraTarget target)
        {
            _target = target;
            _offset = transform.position - _target.transform.position;
            _oldOffset = _offset;
        }

        public void Follow()
        {
            var targetPosition = _target.transform.forward * _forwardOffsetMultiplier + _target.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _smooth);
        }

        public void ChangeOffset(Vector3 offset)
        {
            _offset = offset;
        }

        public void ResetOffset()
        {
            _offset = _oldOffset;
        }
    }
}