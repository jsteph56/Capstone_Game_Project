using UnityEngine;
using Animations;

namespace PropsController
{
    public class AltarController : MonoBehaviour
    {
        [SerializeField] GameObject pillar1;
        [SerializeField] GameObject pillar2;

        private PropsAltar runes;
        private PillarController p1;
        private PillarController p2;

        public bool isActive = false;

        void Start()
        {
            runes = GetComponent<PropsAltar>();
            p1 = pillar1.GetComponent<PillarController>();
            p2 = pillar2.GetComponent<PillarController>();

            isActive = false;
        }

        void Update()
        {
            if (p1.isActive && p2.isActive)
            {
                isActive = true;
            }
        }
    }
}