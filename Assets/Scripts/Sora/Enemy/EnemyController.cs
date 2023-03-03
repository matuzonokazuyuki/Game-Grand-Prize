using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Sora_Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField, Header("当たり判定のスクリプト")] private EnemyTrigger trigger;

        private CompositeDisposable disposables = new CompositeDisposable();

        void Start()
        {
            trigger.GetHitRock()
                .Subscribe(_ => RockHit())
                .AddTo(disposables);
        }

        /// <summary>
        /// 岩が当たったら
        /// </summary>
        private void RockHit()
        {
            Debug.Log("岩が当たったよ");
        }
    }
}