using UnityEngine;
using Player;

namespace Chests
{
    public class PurpleChest : MonoBehaviour
    {
        private GameObject player;
        private ChestController chestCon;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            chestCon = GetComponent<ChestController>();
        }

        void Update()
        {
            if (chestCon.isOpen)
            {
                player.GetComponent<PlayerController>().hasPurpleRune = true;
            }
        }
    }
}