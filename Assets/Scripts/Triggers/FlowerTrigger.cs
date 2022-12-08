using UnityEngine;
using Player;

namespace Triggers
{
    public class FlowerTrigger : MonoBehaviour
    {
        private GameObject player;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != player) return;

            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerController>().FadeOutObject();
        }
    }
}