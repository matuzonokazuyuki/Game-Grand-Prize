using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Yuen.Enemy
{
    public class RussiaFlyAnimation : MonoBehaviour
    {
        [SerializeField] Animator animator;


        private void Start ()
        {
            StartCoroutine(Fly());
        }

        //ロシア飛び処理
        private IEnumerator Fly()
        {
            while (true)
            {
                transform.eulerAngles = new Vector3(0, 90f, 0);
                animator.SetBool("IsFly", true);
                yield return new WaitForSeconds(1);
                animator.SetBool("IsFly", false);
                yield return new WaitForSeconds(2);

                transform.eulerAngles = new Vector3(0, 270f, 0);
                animator.SetBool("IsFly", true);
                yield return new WaitForSeconds(1);
                animator.SetBool("IsFly", false);
                yield return new WaitForSeconds(2);

            }
        }
        
    }
}
