using UnityEngine;
using Player;

namespace Interactable
{
    public class PurpleRunePillar : MonoBehaviour
    {
        private GameObject player;
        private bool activeTrigger = false;

        public SpriteRenderer purpleRune;
        public bool isActive;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (activeTrigger && player.GetComponent<PlayerController>().hasPurpleRune && Input.GetKeyDown(KeyCode.E))
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