using UnityEngine;

namespace PropsControllers
{
    public class LayerChange : MonoBehaviour
    {
        private GameObject player;
        private SpriteRenderer spr;
        private Vector2 position;
        private string startLayerName;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            spr = this.GetComponent<SpriteRenderer>();
            position = this.gameObject.transform.position;
            startLayerName = spr.sortingLayerName;
        }

        void Update()
        {
            Vector2 playerPos = player.transform.position;
            bool below = playerPos.y - .5 > position.y;
            bool sameLayer = player.gameObject.layer == player.gameObject.layer;

            if (below && sameLayer)
            {
                spr.sortingLayerID = SortingLayer.NameToID("Top");
            }
            else
            {
                spr.sortingLayerID = SortingLayer.NameToID(startLayerName);
            }
        }
    }
}