using UnityEngine;
using UniRx;
using System;

namespace Sora_Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        private Subject<Unit> hitRock = new Subject<Unit>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Rock"))
            {
                hitRock.OnNext(Unit.Default);
            }
        }

        public IObservable<Unit> GetHitRock()
        {
            return hitRock;
        }
    }
}