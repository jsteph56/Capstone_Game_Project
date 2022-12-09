using UnityEngine;
using Animations;
using Interactable;
using Player;

namespace PropsControllers
{
    public class PlayerAltar : MonoBehaviour
    {
        [SerializeField] GameObject bluePillar;
        [SerializeField] GameObject redPillar;
        [SerializeField] GameObject purplePillar;
        [SerializeField] GameObject greenPillar;

        private GameObject player;
        private PlayerPropsAltar propsAltar;
        private bool r1, r2, r3, r4, activeTrigger, isActive = false;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            propsAltar = GetComponent<PlayerPropsAltar>();
        }

        void Update()
        {
            if (activeTrigger && isActive && !player.GetComponent<PlayerController>().turnStone)
            {
                player.GetComponent<PlayerController>().turnStone = true;
                player.GetComponent<PlayerController>().FadeOutObject();
            }

            CheckRunes();
        }

        private void CheckRunes()
        {
            if (bluePillar.GetComponent<BlueRunePillar>().isActive && !r1)
            {
                propsAltar.runes.Add(bluePillar.GetComponent<BlueRunePillar>().blueRune);
                r1 = true;
            }

            if (redPillar.GetComponent<RedRunePillar>().isActive && !r2)
            {
                propsAltar.runes.Add(redPillar.GetComponent<RedRunePillar>().redRune);
                r2 = true;
            }

            if (purplePillar.GetComponent<PurpleRunePillar>().isActive && !r3)
            {
                propsAltar.runes.Add(purplePillar.GetComponent<PurpleRunePillar>().purpleRune);
                r3 = true;
            }

            if (greenPillar.GetComponent<GreenRunePillar>().isActive && !r4)
            {
                propsAltar.runes.Add(greenPillar.GetComponent<GreenRunePillar>().greenRune);
                r4 = true;
            }

            if (r1 && r2 && r3 && r4)
            {
                isActive = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            activeTrigger = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;
            
            activeTrigger = false;
        }
    }
}