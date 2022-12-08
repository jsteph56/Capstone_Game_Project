using System.Collections.Generic;
using UnityEngine;
using PropsController;

//when something get into the alta, make the runes glow
namespace Animations
{

    public class PropsAltar : MonoBehaviour
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
            altarCon = altar.GetComponent<AltarController>();
        }

        void Update()
        {
            if (CheckActive()) targetColor = new Color(1, 1, 1, 1);
            else targetColor = new Color(1, 1, 1, 0);

            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }

        private bool CheckActive()
        {
            return altarCon.isActive;
        }
    }
}
