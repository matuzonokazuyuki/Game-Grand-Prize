using UnityEngine;
using UniRx;
using System;

namespace Sora_Player
{
    public class ScreenInDetermine : MonoBehaviour
    {
        private Subject<bool> determine = new Subject<bool>();

        private void OnBecameInvisible()
        {
            determine.OnNext(false);
        }

        private void OnBecameVisible()
        {
            determine.OnNext(true);
        }

        public IObservable<bool> GetDetermine()
        {
            return determine;
        }
    }
}