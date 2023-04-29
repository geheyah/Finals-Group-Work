using UnityEngine;

public class Type2enemyScript : MonoBehaviour
{

    // Movements
    public float speed; // Enemy movement speed
    public float enemySightRange; // Set the maximum distance of the raycast
    public Transform player; // Add player here
    private bool isFollowingPlayer = false;

    public LayerMask obstacleLayerMask; 


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

        RaycastHit[] hitInfos;
        Vector3 raycastOrigin = transform.position;

        Vector3 leftraycastDirection = Vector3.left; // Cast ray to the left
        Vector3 righttraycastDirection = Vector3.right; //cast ray to the right
        Vector3 backtraycastDirection = Vector3.back; //cast ray to the back
        Vector3 forwardtraycastDirection = Vector3.forward; //cast ray to the forward

        hitInfos = Physics.RaycastAll(raycastOrigin, leftraycastDirection, enemySightRange);
        foreach (RaycastHit hitInfo in hitInfos)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("left detected");
                isFollowingPlayer = true;
                return;
            }
        }

        hitInfos = Physics.RaycastAll(raycastOrigin, righttraycastDirection, enemySightRange);
        foreach (RaycastHit hitInfo in hitInfos)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("right detected");
                isFollowingPlayer = true;
                return;
            }
        }

        hitInfos = Physics.RaycastAll(raycastOrigin, backtraycastDirection, enemySightRange);
        foreach (RaycastHit hitInfo in hitInfos)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("back detected");
                isFollowingPlayer = true;
                return;
            }
        }

        hitInfos = Physics.RaycastAll(raycastOrigin, forwardtraycastDirection, enemySightRange);
        foreach (RaycastHit hitInfo in hitInfos)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("forward detected");
                isFollowingPlayer = true;
                return;
            }
        }

        isFollowingPlayer = false;

        Debug.DrawRay(raycastOrigin, leftraycastDirection * enemySightRange, Color.red);
        Debug.DrawRay(raycastOrigin, righttraycastDirection * enemySightRange, Color.red);
        Debug.DrawRay(raycastOrigin, backtraycastDirection * enemySightRange, Color.red);
        Debug.DrawRay(raycastOrigin, forwardtraycastDirection * enemySightRange, Color.red);
    }

    void enemyAgro()
    {
        float stoppingDistance = 1.5f; // Adjust this value to change the distance between enemy and player
        Vector3 targetPosition = player.position + (transform.position - player.position).normalized * stoppingDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Debug.Log("Following player");
    }

}
