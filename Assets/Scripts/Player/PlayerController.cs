using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Animator animator;
        [SerializeField] AudioSource audioSource;
        [SerializeField] float fadeSpeed;

        [SerializeField] Sprite stoneManSprite;

        private bool fadeOut, fadeIn;

        public Transform fadePosition;
        public bool turnStone = false;
        public bool hasBlueRune, hasRedRune, hasPurpleRune, hasGreenRune = false;

        States state;

        struct States
        {
            public bool idle, running;

            public void SetIdle()
            {
                running = false;

                idle = true;
            }

            public void SetRunning()
            {
                idle = false;

                running = true;
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
            
            if (state.running) 
            {
                animator.SetTrigger("Running");
                audioSource.mute = false;
            }
            else if (state.idle)
            {
                animator.SetTrigger("Idle");
                audioSource.mute = true;
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
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

                    if (turnStone)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = stoneManSprite;
                        this.transform.localScale = new Vector3(1, 1, 1);
                        animator.enabled = false;
                    }

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

                    if (turnStone)
                    {
                        GetComponent<PlayerMovement>().enabled = false;
                        StartCoroutine(EndGame());
                    }
                }
            }
        }

        IEnumerator EndGame()
        {
            SceneManager.LoadScene(2);
            yield return null;
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


