using UnityEngine;
using Player;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float followSpeed;

    [SerializeField] GameObject blueRunestone;
    
    void Update()
    {
        PlayerController playerCon = player.gameObject.GetComponent<PlayerController>();
        transform.position = Vector3.Lerp(transform.position, player.position + offset, followSpeed);


        if (playerCon.hasBlueRune)
        {
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (playerCon.hasRedRune)
        {
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (playerCon.hasPurpleRune)
        {
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (playerCon.hasGreenRune)
        {
            transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
