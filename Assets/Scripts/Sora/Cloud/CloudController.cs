using UnityEngine;
using Sora_Constans;
using Sora_Extemsion;
using UniRx;
using UniRx.Triggers;

namespace Sora_Cloud
{
    public class CloudController : MonoBehaviour
    {
        [SerializeField, Header("雲のタイプ")] private CloudGroup cloudType;
        private float speed;
        private CloudData data;

        private CompositeDisposable disposables = new CompositeDisposable();

        async void Start()
        {
            data = await AddressLoader.AddressLoder<CloudData>(AddressableAssetAddress.CLOUD_DATA);
            speed = data.GetCloudSpeed(cloudType);
            speed /= 10;
        }

        private void Move()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f))
                .AddTo(disposables);
        }

        private void OnBecameInvisible()
        {
            disposables.Clear();
            Debug.Log("aaa");
        }

        private void OnBecameVisible()
        {
            Move();
        }

        private void OnDestroy()
        {
            disposables.Dispose();
        }
    }
}