using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yuen.UI
{
    public class SkillGaugeSystem : MonoBehaviour
    {
        private Slider slider;
        private void Awake()
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
        /// <summary>
        /// スキルゲージの変更
        /// </summary>
        /// <param name="value">変更するvalue</param>
        public void UpdateGauge(float value)
        {
            slider.value = value;
        }
        /// <summary>
        /// スキルゲージのリセット
        /// </summary>
        /// <param name="maxValue">最大値のvalue</param>
        public void ResetGauge(float maxValue)
        {
            slider.maxValue = maxValue;
            slider.value = slider.maxValue;
        }
    }
}
