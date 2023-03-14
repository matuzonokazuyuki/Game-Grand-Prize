using UnityEngine;

namespace Sora_Constans
{
    [CreateAssetMenu(menuName = "Datas/SkillData")]
    public class SkillData : ScriptableObject
    {
        [SerializeField, Header("スキルゲージの最大数")] private int skillPointMaxValue = 100;
        [SerializeField, Header("スキル使用時に進む速さ")] private int skillPower = 10;
        [SerializeField, Header("スキル使用時間")] private float seconds = 10f;

        /// <summary>
        /// スキルゲージの最大値
        /// </summary>
        /// <returns>最大値</returns>
        public int GetSkillPointMaxValue()
        {
            return skillPointMaxValue;
        }

        /// <summary>
        /// スキル使用時のプレイヤーに加える速度
        /// </summary>
        /// <returns>速度</returns>
        public int GetSkillPower()
        {
            return skillPower;
        }

        /// <summary>
        /// スキル使用時間
        /// </summary>
        /// <returns>時間</returns>
        public float GetSkillSeconds()
        {
            return seconds;
        }
    }
}