using UnityEngine;

namespace PropsController
{
    public class DoorController : MonoBehaviour
    {
        private bool doorTrigger;

        void Update()
        {
            if (doorTrigger && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Move to new Scene");
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            doorTrigger = true;
            this.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            doorTrigger = false;
            this.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}