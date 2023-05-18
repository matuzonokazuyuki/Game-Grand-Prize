using UnityEngine;

[CreateAssetMenu(menuName = "Datas/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField, Header("移動速度")] private float moveSpeed = 5f;
    [SerializeField, Header("持てる風船の上限")] private int maxBalloonLimit = 10;
    [SerializeField, Header("風船の最大ストック数")] private int balloonStockMaxLimit = 10;
    [SerializeField, Header("プレイヤーのデフォルトの重力")] private float playerGravity = 10f;
    [SerializeField, Header("風船一個の上昇量")] private float upwardQuantity = 3.334f;
    [SerializeField, Header("最大のスキルポイントの数")] int maxSkillPoint = 10;
    [SerializeField, Header("増やすスキルポイントを増やすときの数")] int skillPoint = 1;


    /// 移動速度
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    /// 持てる風船の最大数
    public int GetMaxBalloonLimit()
    {
        return maxBalloonLimit;
    }

    /// 風船ストックの最大数
    public int GetBalloonStricMaxLimit()
    {
        return balloonStockMaxLimit;
    }

    /// プレイヤーの重力
    public float GetPlayerGravity()
    {
        return playerGravity;
    }

    /// 風船一個の上昇量
    public float GetUpwardQuantity()
    {
        return upwardQuantity;
    }
    public int GetMaxSkillPoint()
    {
        return maxSkillPoint;
    }
    public int GetSkillPoint()
    {
        return skillPoint;
    }
}
