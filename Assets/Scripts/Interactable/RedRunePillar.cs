using UnityEngine;
using Player;

namespace Interactable
{
    public class RedRunePillar : MonoBehaviour
    {
        private GameObject player;
        private bool activeTrigger = false;

        public SpriteRenderer redRune;
        public bool isActive;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (activeTrigger && player.GetComponent<PlayerController>().hasRedRune && Input.GetKeyDown(KeyCode.E))
            {
                isActive = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                activeTrigger = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                activeTrigger = false;
            }
        }
    }
}