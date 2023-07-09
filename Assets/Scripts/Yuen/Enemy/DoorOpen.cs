using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class DoorOpen : MonoBehaviour
    {
        [SerializeField] float openSpeed;
        Vector3 nowPosition;
        private void Start()
        {
            nowPosition = gameObject.transform.position;
        }
        public void Open()
        {
            transform.position += new Vector3(0, openSpeed * Time.deltaTime, 0);
        }
        public void Stop()
        {
            transform.position += new Vector3(0, 0, 0);
        }
        public void ResetDoor()
        {
            transform.position = nowPosition;
        }
    }
}
