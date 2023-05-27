using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Yuen_Addressable
{
    public static class AddressableLoder
    {
        public static async UniTask<T> AddressLoder<T>(string address)
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
            await handle.Task;
            return handle.Result;
        }
    }
}