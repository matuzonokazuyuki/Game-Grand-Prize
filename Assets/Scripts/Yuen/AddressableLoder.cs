using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;

namespace Yuen_Addressable
{
    public static class AddressableLoder
    {
        public static async UniTask<T> AddressLoder<T>(string address)
        {
            AsyncOperationHandle<T> loader = Addressables.LoadAssetAsync<T>(address);
            await loader.Task;
            return loader.Result;
        }
    }
}