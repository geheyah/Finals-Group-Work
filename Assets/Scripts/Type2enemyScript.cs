using UnityEngine;

public class Type2enemyScript : MonoBehaviour
{
    // Movements
    public float speed; // Enemy movement speed
    public float raycastDistance; // Set the maximum distance of the raycast
    public Transform player; // Add player here
    private float startPosition;
    public float travelDistance;
    private bool isFollowingPlayer = false;

    // Attacks
    public GameObject enemyAttack_01Prefab; // Prefab of enemy attack



    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    {
        enemySight();

        if (isFollowingPlayer)
        {
            enemyAgro();
        }

    }

    void enemySight()
    {
        // Cast ray to the left
        Vector3 leftraycastDirection = Vector3.left;
        Vector3 righttraycastDirection = Vector3.right;
        RaycastHit hitInfo;
        Vector3 raycastOrigin = transform.position;

        Debug.DrawRay(raycastOrigin, leftraycastDirection * raycastDistance, Color.red);
        Debug.DrawRay(raycastOrigin, righttraycastDirection * raycastDistance, Color.red);

        if (Physics.Raycast(raycastOrigin, leftraycastDirection, out hitInfo, raycastDistance))
        {
            // Check if the raycast hits a player
            if (hitInfo.collider.CompareTag("Player"))
            {
                //set the isFollowingPlayer to true and start enemyAgro
                isFollowingPlayer = true;
                Debug.Log("left detected");
            }
        }
        else
        {
            //if not player is not getting detected return isFollowingPlayer to false and stop following player
            isFollowingPlayer = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition, transform.position.y, transform.position.z), speed * Time.deltaTime);

        }

        if (Physics.Raycast(raycastOrigin, righttraycastDirection, out hitInfo, raycastDistance))
        {
            // Check if the raycast hits a player
            if (hitInfo.collider.CompareTag("Player"))
            {
                //set the isFollowingPlayer to true and start enemyAgro
                Debug.Log("right detected");
                isFollowingPlayer = true;
            }
        }
    }

    void enemyAgro()
    {
        float stoppingDistance = 1.5f; // Adjust this value to change the distance between enemy and player
        Vector3 targetPosition = player.position + (transform.position - player.position).normalized * stoppingDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Debug.Log("Following player");
    }
}

