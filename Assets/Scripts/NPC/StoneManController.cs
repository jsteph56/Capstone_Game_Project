using UnityEngine;
using PropsControllers;
using Pathfinding;

namespace NPC
{
    public class StoneManController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] GameObject altar;

        private AltarController altarCon;
        private float walkSpeed;

        void Start()
        {
            altarCon = altar.GetComponent<AltarController>();
        }

        void Update()
        {
            if (altarCon.isActive)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                GetComponent<AIPath>().canMove = true;
            }

            if (GetComponent<AIPath>().reachedDestination)
            {
                GetComponent<AIPath>().enabled = false;
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}