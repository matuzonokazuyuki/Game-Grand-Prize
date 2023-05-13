using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //player reduce balloon
    public void DestoryBall(InputAction.CallbackContext callback)
    {
        if (!callback.started) return;
    }

    //player take iteam
    public void TakeIteam(InputAction.CallbackContext callback)
    {
        if (!callback.started) return;

        //take iteam
        Debug.Log("take");

    }

    #region skill
    //player use skill
    public void UseSkill()
    {

    }

    #endregion
}
