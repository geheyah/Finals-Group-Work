using UnityEngine;

public class Type2enemyScript : MonoBehaviour
{

    // Movements
    public float speed; // Enemy movement speed
    public float enemySightRange; // Set the maximum distance of the raycast
    public Transform player; // Add player here
    private bool isFollowingPlayer = false;

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
        RaycastHit hitInfo;
        Vector3 raycastOrigin = transform.position;

        Vector3 leftraycastDirection = Vector3.left;         // Cast ray to the left
        Vector3 righttraycastDirection = Vector3.right;      // Cast ray to the right
        Vector3 forwardtraycastDirection = Vector3.forward;  // Cast ray to the forward
        Vector3 backtraycastDirection = Vector3.back;        // Cast ray to the back

        //left raycast
        if (Physics.Raycast(raycastOrigin, leftraycastDirection, out hitInfo, enemySightRange))
        {
            // Check if the raycast hits a player
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("left detected");
                isFollowingPlayer = true; //set the isFollowingPlayer to true and start enemyAgro
            }
        }
        //back raycast
        else if (Physics.Raycast(raycastOrigin, backtraycastDirection, out hitInfo, enemySightRange))
        {
            if (hitInfo.collider.CompareTag("Player")) // Check if the raycast hits a player
            {
                Debug.Log("right detected"); //set the isFollowingPlayer to true and start enemyAgro
                isFollowingPlayer = true;
            }
        }

        //right raycast
        else if (Physics.Raycast(raycastOrigin, righttraycastDirection, out hitInfo, enemySightRange))
        {
            if (hitInfo.collider.CompareTag("Player")) // Check if the raycast hits a player
            {
                Debug.Log("right detected"); //set the isFollowingPlayer to true and start enemyAgro
                isFollowingPlayer = true;
            }
        }

        //forward raycast
        else if (Physics.Raycast(raycastOrigin, forwardtraycastDirection, out hitInfo, enemySightRange))
        {

            if (hitInfo.collider.CompareTag("Player"))   // Check if the raycast hits a player
            {

                Debug.Log("right detected");
                isFollowingPlayer = true;   //set the isFollowingPlayer to true and start enemyAgro
            }
        }

        else
        {
            isFollowingPlayer = false;
        }

        Debug.DrawRay(raycastOrigin, leftraycastDirection * enemySightRange, Color.red);
        Debug.DrawRay(raycastOrigin, righttraycastDirection * enemySightRange, Color.red);
        Debug.DrawRay(raycastOrigin, forwardtraycastDirection * enemySightRange, Color.red);
        Debug.DrawRay(raycastOrigin, backtraycastDirection * enemySightRange, Color.red);
    }

    void enemyAgro()
    {
        float stoppingDistance = 1.5f; // Adjust this value to change the distance between enemy and player
        Vector3 targetPosition = player.position + (transform.position - player.position).normalized * stoppingDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Debug.Log("Following player");
    }

}
