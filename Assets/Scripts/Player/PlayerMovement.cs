using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        
        [SerializeField] public float moveSpeed;

        private Vector2 movement;

        void Update()
        {
            GetInput();
            
        }
        
        void FixedUpdate()
        {
            rb.velocity = movement * moveSpeed;
        }

        private void GetInput()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movement = new Vector2(moveX, moveY).normalized;
        }
    }
}
