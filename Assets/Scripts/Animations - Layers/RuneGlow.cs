using UnityEngine;

namespace Animations
{
    public class RuneGlow : MonoBehaviour
    {
        [SerializeField] float fadeSpeed;
        
        private bool fadeIn = false;

        void Update()
        {
            if (fadeIn)
            {
                Fade();
            }
        }

        private void Fade()
        {
            Color objectColor = GetComponent<SpriteRenderer>().material.color;
            Debug.Log(GetComponent<SpriteRenderer>().sprite);
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<SpriteRenderer>().material.color = objectColor;

            if (objectColor.a >= 1) fadeIn = false;
        }

        public void FadeInObject()
        {
            fadeIn = true;
        }
    }
}