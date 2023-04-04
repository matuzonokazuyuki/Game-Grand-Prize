using UnityEngine;
using Sora_Constans;

namespace Sora_Gimmick
{
    public class AirFlowController : MonoBehaviour
    {
        [SerializeField, Header("気流のタイプ")] private AirflowType type;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagName.Player))
            {
                // TODO: 気流の処理
                //other.GetComponent<CharacterMovement>().
            }
        }
    }
}