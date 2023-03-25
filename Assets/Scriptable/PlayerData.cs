using UnityEngine;

[CreateAssetMenu(menuName = "Datas/PlayerData")]
public class PlayerData : ScriptableObject
{
    //move speed
    [Space(5)][SerializeField] float moveSpeed;

    //[Space(5)][SerializeField] float weight;

    //set balloon
    [Space(10)][Header("�o���[���̐�")]
    public GameObject[] balloon;

    //set number of balloon gravity
    [Header("���̃o���[���̕�����")]
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
