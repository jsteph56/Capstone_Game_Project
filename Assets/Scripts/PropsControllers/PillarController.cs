using UnityEngine;
using Animations;

namespace PropsController
{
    public class PillarController : MonoBehaviour
    {
        private bool activeTrigger;
        
        public bool isActive;

        void Start()
        {
            activeTrigger = false;
            isActive = false;
        }

        void Update()
        {
            if (activeTrigger && Input.GetKeyDown(KeyCode.E))
            {
                this.GetComponent<SpriteColorAnimation>().enabled = true;
                isActive = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                activeTrigger = true;

                if (!isActive)
                {
                    this.GetComponentInChildren<MeshRenderer>().enabled = true;
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                activeTrigger = false;
                this.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
        }
    }
}
