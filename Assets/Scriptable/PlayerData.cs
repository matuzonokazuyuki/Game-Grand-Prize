using UnityEngine;

[CreateAssetMenu(menuName = "Datas/PlayerData")]
public class PlayerData : ScriptableObject
{
    //move speed
    [Space(5)][SerializeField] float moveSpeed;

    //[Space(5)][SerializeField] float weight;

    //set balloon
    [Space(10)][Header("バルーンの数")]
    public GameObject[] balloon;

    //set number of balloon gravity
    [Header("一つ一つのバルーンの浮く力")]
    [Multiline] public string text;
    public int[] BalloonGravity;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    /*
    public float GetWeight()
    {
        return weight;
    }
    */

}
