using UnityEngine;
using Player;
using Animations;

namespace Interactable
{
    public class BlueRunePillar : MonoBehaviour
    {   
        private GameObject player;
        private bool activeTrigger = false;

        public SpriteRenderer blueRune;
        public bool isActive;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (activeTrigger && player.GetComponent<PlayerController>().hasBlueRune && Input.GetKeyDown(KeyCode.E))
            {
                isActive = true;
                transform.Find("Glow").gameObject.GetComponent<SpriteRenderer>().enabled = true;
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