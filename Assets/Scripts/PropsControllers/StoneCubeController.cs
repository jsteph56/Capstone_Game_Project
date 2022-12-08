using UnityEngine;
using Pathfinding;

namespace PropsController
{
    public class StoneCubeController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "Stone Man") return;

            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}