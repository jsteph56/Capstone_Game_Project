using UnityEngine;

namespace Interactable
{
    public class ChestController : MonoBehaviour
    {
        [SerializeField] Sprite closedChest;
        
        private GameObject player;
        private bool chestTrigger;
        
        public bool isOpen = false;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (chestTrigger && Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<SpriteRenderer>().sprite = closedChest;
                isOpen = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != player) return;

            GetComponentInChildren<MeshRenderer>().enabled = true;
            chestTrigger = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject != player) return;

            GetComponentInChildren<MeshRenderer>().enabled = false;
            chestTrigger = false;
        }
    }
}