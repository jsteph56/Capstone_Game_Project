using UnityEngine;
using Pathfinding;

public class Bandit : MonoBehaviour {

    [SerializeField] Transform trans;
    [SerializeField] Transform pathEnd;
    [SerializeField] float moveSpeed;
    [SerializeField] float aggroRange;

    private Animator animator;
    private Rigidbody2D rb;
    private GameObject player;
    private AIDestinationSetter desinationSetter;
    private Transform pathStart;
    private bool isIdle, isDead = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        pathStart = trans;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPos = player.transform.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(trans.position, aggroRange);
    }
}
