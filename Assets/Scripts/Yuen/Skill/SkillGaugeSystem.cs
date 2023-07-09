using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yuen.UI
{
    public class SkillGaugeSystem : MonoBehaviour
    {
        Slider slider;

        private void Start()
        {
            if (slider == null)
            {
                slider = GetComponent<Slider>();
            }
            else
            {
                Debug.LogError("Skill Guage Null");
            }
        }
        public void UpdateGauge(float value)
        {
            slider.value = value;
        }

        public void resetGauge(float maxValue)
        {
            slider.maxValue = maxValue;
            slider.value = slider.maxValue;
        }
    }
}
