using Assets.Scripts.Infra.RaycastModule;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Infra.RaycastModule
{
    public class RayCaster : MonoBehaviour
    {
        public event Action<Vector3> RayHitEvent;

        [SerializeField] private ARRaycastManager _arRaycastManager;

        private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

        private void Update()
        {
            if(Input.touchCount == 0)
            {
                return;
            }

            var touch = Input.GetTouch(0);

            if (UIRaycastBlocker.IsPointerOverUIObject(touch.position))
            {
                return;
            }

            if (touch.phase == TouchPhase.Began && _arRaycastManager.Raycast(touch.position, _hits, TrackableType.PlaneWithinPolygon))
            {
                RayHitEvent?.Invoke(_hits[0].pose.position);
            }
        }
    }
}