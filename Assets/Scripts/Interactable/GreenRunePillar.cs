using UnityEngine;
using Player;

namespace Interactable
{
    public class GreenRunePillar : MonoBehaviour
    {
        private GameObject player;
        private bool activeTrigger = false;

        public SpriteRenderer greenRune;
        public bool isActive;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (activeTrigger && player.GetComponent<PlayerController>().hasGreenRune && Input.GetKeyDown(KeyCode.E))
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