using UnityEngine;

namespace Animations
{
    public class RuneGlow : MonoBehaviour
    {
        [SerializeField] float fadeSpeed;
        
        private bool playerTrigger, fadeIn = false;

        private void Fade()
        {
            Color objectColor = this.GetComponent<SpriteRenderer>().material.color;
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