using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Yuen.UI
{
    public class SlideUI : MonoBehaviour
    {
        private Vector2 slideInput;
        [SerializeField] private float slideSpeed;

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = new Vector3(-slideInput.x, 0f, 0f) * slideSpeed * Time.deltaTime;
            // スライドの移動
            transform.Translate(movement);
            slideInput.y = 0;
        }

        /// <summary>
        /// New Input System
        /// </summary>
        /// <param name="context">入力</param>
        public void OnSlide(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                slideInput = context.ReadValue<Vector2>();
            }
        }
    }
}
