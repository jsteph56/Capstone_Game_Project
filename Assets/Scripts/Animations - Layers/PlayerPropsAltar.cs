using System.Collections.Generic;
using UnityEngine;
using PropsControllers;

//when something get into the alta, make the runes glow
namespace Animations
{

    public class PlayerPropsAltar : MonoBehaviour
    {
        [SerializeField] GameObject altar;

        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private AltarController altarCon;
        private Color curColor;
        private Color targetColor;

        void Start()
        {
            targetColor = new Color(1, 1, 1, 0);
            runes = new List<SpriteRenderer>();
        }

        void Update()
        {
            targetColor = new Color(1, 1, 1, 1);

            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}
