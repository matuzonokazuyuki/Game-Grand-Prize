using UnityEngine;

public class DangerWall : MonoBehaviour
{
    [SerializeField]
    private int divideBalloon = 1;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            //風船を割る処理
        }
    }
}
