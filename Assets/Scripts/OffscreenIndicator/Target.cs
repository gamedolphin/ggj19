using UnityEngine;

namespace OffScreenIndicator
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private Color targetColor;
        [SerializeField] private bool needBoxIndicator = true;
        [SerializeField] private bool needArrowIndicator = true;
        [SerializeField] private bool needDistanceText = true;
        private string targetTag = "Target";

        public Color TargetColor
        {
            get
            {
                return targetColor;
            }
        }

        public bool NeedBoxIndicator
        {
            get
            {
                return needBoxIndicator;
            }
        }

        public bool NeedArrowIndicator
        {
            get
            {
                return needArrowIndicator;
            }
        }

        public bool NeedDistanceText
        {
            get
            {
                return needDistanceText;
            }
        }

        private void Awake()
        {
            gameObject.tag = targetTag;
        }

        public float GetDistanceFromCamera(Vector3 cameraPosition)
        {
            float distanceFromCamera = Vector3.Distance(cameraPosition, transform.position);
            return distanceFromCamera;
        }
    }
}
