using UnityEngine;

namespace Sora_Constans
{
    [CreateAssetMenu(menuName = "Datas/CloudData")]
    public class CloudData : ScriptableObject
    {
        [SerializeField, Header("近距離の雲のスピード"), Range(0, 10)] private float shortDistanceCloudSpeed = 3f;
        [SerializeField, Header("中距離の雲のスピード"), Range(0, 10)] private float intermediateDistanceCloudSpeed = 2f;
        [SerializeField, Header("長距離の雲のスピード"), Range(0, 10)] private float longDistanceCloudSpeed = 1f;

        /// <summary>
        /// 雲のスピード
        /// </summary>
        /// <param name="type">距離タイプ</param>
        /// <returns>雲のスピード</returns>
        public float GetCloudSpeed(CloudGroup type)
        {
            switch (type)
            {
                case CloudGroup.ShortDistance:
                    return shortDistanceCloudSpeed;
                case CloudGroup.IntermediateDistance:
                    return intermediateDistanceCloudSpeed;
                case CloudGroup.LongDistance:
                    return longDistanceCloudSpeed;
            }
            return longDistanceCloudSpeed;
        }
    }
}