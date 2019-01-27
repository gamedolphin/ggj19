﻿using UnityEngine;
using UnityEngine.UI;

namespace OffScreenIndicator
{
    public class Indicator : MonoBehaviour
    {
        private Image indicatorImage;
        private Text distanceText;

        public bool Active
        {
            get
            {
                return transform.gameObject.activeInHierarchy;
            }
        }

        void Awake()
        {
            indicatorImage = transform.GetComponent<Image>();
            distanceText = transform.GetComponentInChildren<Text>();
        }

        public void SetImageColor(Color color)
        {
            indicatorImage.color = color;
        }

        public void SetDistanceText(float value)
        {
            distanceText.text = value >=0 ? Mathf.Floor(value) + " m" : "";
        }

        public void SetTextRotation(Quaternion rotation)
        {
            distanceText.rectTransform.rotation = rotation;
        }

        public void Activate(bool value)
        {
            transform.gameObject.SetActive(value);
        }
    }
}
