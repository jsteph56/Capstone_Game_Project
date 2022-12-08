using UnityEngine;

namespace PropsController
{
    public class LayerTrigger : MonoBehaviour
    {
        [SerializeField] int layerNumber;
        
        private GameObject player;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != player) return;

            player.layer = layerNumber;
        }
    }
}
