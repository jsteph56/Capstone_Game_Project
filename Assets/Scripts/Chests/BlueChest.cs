using UnityEngine;
using Player;

namespace Chests
{
    public class BlueChest : MonoBehaviour
    {
        [SerializeField] GameObject objRemove1;
        [SerializeField] GameObject objRemove2;
        [SerializeField] GameObject objRemove3;
        [SerializeField] GameObject objRemove4;

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
                Destroy(objRemove1);
                Destroy(objRemove2);
                Destroy(objRemove3);
                Destroy(objRemove4);

                player.GetComponent<PlayerController>().hasBlueRune = true;
            }
        }
    }
}