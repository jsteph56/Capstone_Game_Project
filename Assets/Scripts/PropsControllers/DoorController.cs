using UnityEngine;
using Player;

namespace PropsController
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] Transform exitPos;
        [SerializeField] Transform fadePosition;
        
        private GameObject player;
        private bool doorTrigger;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (doorTrigger && Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = exitPos.position;
                player.GetComponent<PlayerController>().fadePosition = fadePosition;
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