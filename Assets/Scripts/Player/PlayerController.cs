using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Animator animator;
        [SerializeField] float fadeSpeed;

        private bool fadeOut, fadeIn;

        public Transform fadePosition;

        States state;

        struct States
        {
            public bool idle, running, attacking;

            public void SetIdle()
            {
                running = false;
                attacking = false;

                idle = true;
            }

            public void SetRunning()
            {
                idle = false;
                attacking = false;

                running = true;
            }

            public void SetAttacking()
            {
                idle = false;
                running = false;

                attacking = true;
            }
        }

        void Start()
        {
            state.idle = true;
        }
        
        void Update()
        {
            if (!fadeOut) KeyInput();
            Fade();
            
            if (state.running) animator.SetTrigger("Running");
            else if (state.idle) animator.SetTrigger("Idle");

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        private void KeyInput()
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                state.SetRunning();
                //return;
            }
            else
            {
                state.SetIdle();
            }
        }

        public void Fade()
        {
            if (fadeOut)
            {
                Color objectColor = this.GetComponent<SpriteRenderer>().material.color;
                float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                this.GetComponent<SpriteRenderer>().material.color = objectColor;

                if (objectColor.a <= 0)
                {
                    transform.position = fadePosition.position;
                    fadeOut = false;
                    FadeInObject();
                }
            }

            if (fadeIn)
            {
                Color objectColor = this.GetComponent<SpriteRenderer>().material.color;
                float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                this.GetComponent<SpriteRenderer>().material.color = objectColor;

                if (objectColor.a >= 1)
                {
                    GetComponent<PlayerMovement>().enabled = true;
                    fadeIn = false;
                }
            }
        }

        public void FadeOutObject()
        {
            fadeOut = true;
        }

        public void FadeInObject()
        {
            fadeIn = true;
        }
    }
}


