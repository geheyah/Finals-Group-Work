using UnityEngine;

public class Type1enemyScript : MonoBehaviour
{

    // Movements
    public float speed; // Enemy movement speed
    public float raycastDistance; // Set the maximum distance of the raycast
    public Transform player; // Add player here
    private float startPosition;
    public float travelDistance;

    // Attacks
    public GameObject enemyAttack_01Prefab; // Prefab of enemy attack

    private bool isFollowingPlayer = false;

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
        else
        {
            patrolMovement();
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
                isFollowingPlayer = true;
                Debug.Log("left detected");
            }
        }
        else
        {
            isFollowingPlayer = false;
        }

        if (Physics.Raycast(raycastOrigin, righttraycastDirection, out hitInfo, raycastDistance))
        {
            // Check if the raycast hits a player
            if (hitInfo.collider.CompareTag("Player"))
            {
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

    void patrolMovement()
    {
        // Calculate the horizontal movement based on a sine wave
        float movement = Mathf.Sin(Time.time * speed) * travelDistance;
        // Calculate the direction to move based on the sine wave
        Vector3 direction = new Vector3(movement, 0f, 0f);
        // Move the enemy in the calculated direction
        transform.position += direction * speed * Time.deltaTime;
    }
}
