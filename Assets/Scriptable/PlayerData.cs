using UnityEngine;

[CreateAssetMenu(menuName = "Datas/PlayerData")]
public class PlayerData : ScriptableObject
{
    //move speed
    [Space(5)][SerializeField] float moveSpeed;

    //[Space(5)][SerializeField] float weight;

    //set balloon
    [Space(10)] public GameObject[] balloon;

    //set number of balloon gravity
    [Header("Balloon Gravity Parameter")]
    [Tooltip("3 balloon ~490")]
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
