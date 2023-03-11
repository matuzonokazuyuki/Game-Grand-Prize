using UnityEngine;

namespace Sora_Slill
{
    public class SkillItem : MonoBehaviour
    {
        [SerializeField, Header("追加スキルポイント"), Tooltip("説明"), Range(0, 10)]
        private int skillPoint = 10;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SkillUIPresenter.AddSkillGagePoint(skillPoint);
                Destroy(gameObject);
            }
        }
    }
}