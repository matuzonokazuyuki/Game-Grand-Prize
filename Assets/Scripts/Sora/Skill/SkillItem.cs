using UnityEngine;

namespace Sora_Slill
{
    public class SkillItem : MonoBehaviour
    {
        [SerializeField, Header("追加スキルポイント")]
        private int skillPoint = 10;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SkillUIPresenter.AddSkillGagePoint(skillPoint);
                Destroy(gameObject);
            }
        }
    }
}