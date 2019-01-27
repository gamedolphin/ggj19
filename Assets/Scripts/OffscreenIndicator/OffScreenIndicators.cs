using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OffScreenIndicator
{
    public class OffScreenIndicators : MonoBehaviour
    {
        private Camera mainCamera {
            get {
                return Camera.main;
            }
        }
        private Vector3 screenCentre;
        private Vector3 screenBounds;
        private string targetTag = "Target";

        [Range(0.5f, 0.9f)]
        public float screenBoundOffset = 0.9f;

        void Awake()
        {
            screenCentre = new Vector3(Screen.width, Screen.height, 0) / 2;
            screenBounds = screenCentre * screenBoundOffset;
        }

        void Update()
        {
            DeactivateAllIndicators();
        }

        void LateUpdate()
        {
            Paint();
        }

        void Paint()
        {
            Debug.Log(mainCamera);
            if(mainCamera == null) return;
            GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);
            List<Target> targets = new List<Target>();
            objects.ToList().ForEach(obj =>
            {
                Target target = obj.GetComponent<Target>();
                if (target) { targets.Add(target); }
            });

            foreach (Target target in targets)
            {
                Vector3 screenPosition = OffScreenIndicatorCore.GetScreenPosition(mainCamera, target.transform.position);
                bool isTargetVisible = OffScreenIndicatorCore.IsTargetVisible(screenPosition);
                float distanceFromCamera = target.NeedDistanceText ? target.GetDistanceFromCamera(mainCamera.transform.position) : float.MinValue;
                Indicator indicator = null;

                if (target.NeedBoxIndicator && isTargetVisible)
                {
                    screenPosition.z = 0;
                    indicator = BoxObjectPool.current.GetPooledObject();
                    indicator.SetDistanceText(float.MinValue);
                }
                else if (target.NeedArrowIndicator && !isTargetVisible)
                {
                    float angle = float.MinValue;
                    OffScreenIndicatorCore.GetArrowIndicatorPositionAndAngle(ref screenPosition, ref angle, screenCentre, screenBounds);
                    indicator = ArrowObjectPool.current.GetPooledObject();
                    indicator.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
                    indicator.SetDistanceText(distanceFromCamera);
                }
                if (indicator)
                {
                    indicator.SetImageColor(target.TargetColor);
                    indicator.transform.position = screenPosition;
                    indicator.SetTextRotation(Quaternion.identity);
                    indicator.Activate(true);
                }
            }
        }

        private void DeactivateAllIndicators()
        {
            BoxObjectPool.current.DeactivateAllPooledObjects();
            ArrowObjectPool.current.DeactivateAllPooledObjects();
        }
    }
}
