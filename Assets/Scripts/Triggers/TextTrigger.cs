using UnityEngine;

namespace Triggers
{
    public class TextTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            this.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            this.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}