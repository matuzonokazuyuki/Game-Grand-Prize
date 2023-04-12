using UnityEngine;

[CreateAssetMenu(menuName = "Datas/PlayerData")]
public class PlayerData : ScriptableObject
{
    //move speed
    [SerializeField, Header("移動速度")] private float moveSpeed = 5f;
    [SerializeField, Header("持てる風船の上限")] private int maxBalloonLimit = 10;
    [SerializeField, Header("風船の最大ストック数")] private int balloonStockMaxLimit = 20;
    [SerializeField, Header("風船4個の上昇上限")] private float fourBalloonUpwardMax = 5f;
    [SerializeField, Header("風船5個の上昇上限")] private float fiveBalloonUpwardMax = 8f;
    [SerializeField, Header("プレイヤーのデフォルトの重力")] private float playerGravity = 3f;
    [SerializeField, Header("風船一個の上昇量")] private float upwardQuantity = 1f;

    /// <summary>
    /// 移動速度
    /// </summary>
    /// <returns>速度</returns>
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    /// <summary>
    /// 持てる風船の最大数
    /// </summary>
    /// <returns>最大数</returns>
    public int GetMaxBalloonLimit()
    {
        return maxBalloonLimit;
    }

    /// <summary>
    /// 風船ストックの最大数
    /// </summary>
    /// <returns>最大数</returns>
    public int GetBalloonStricMaxLimit()
    {
        return balloonStockMaxLimit;
    }

    /// <summary>
    /// 四つ出しているときの上昇限界
    /// </summary>
    /// <returns>上昇限界</returns>
    public float GetFourBalloonUpwardMax()
    {
        return fourBalloonUpwardMax;
    }

    /// <summary>
    /// 五つ出しているときの上昇限界
    /// </summary>
    /// <returns>上昇限界</returns>
    public float GetFiveBalloonUpwardMax()
    {
        return fiveBalloonUpwardMax;
    }

    /// <summary>
    /// プレイヤーの重力
    /// </summary>
    /// <returns>重力</returns>
    public float GetPlayerGravity()
    {
        return playerGravity;
    }

    /// <summary>
    /// 風船一個の上昇量
    /// </summary>
    /// <returns>上昇量</returns>
    public float GetUpwardQuantity()
    {
        return upwardQuantity;
    }
}
