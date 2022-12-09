using UnityEngine;
using UnityEngine.SceneManagement;

namespace PropsController
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] int sceneIndex;
        private bool doorTrigger;

        void Update()
        {
            if (doorTrigger && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            doorTrigger = true;
            this.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player") return;

            doorTrigger = false;
            this.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}