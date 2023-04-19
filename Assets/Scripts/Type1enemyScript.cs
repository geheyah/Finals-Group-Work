using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1enemyScript : MonoBehaviour
{
    //enemy stats
    private float health;
    public float maxHealth;

    //movements
    public float speed; //enemy movement speed
    public float raycastDistance; // set the maximum distance of the raycast
    private bool followingPlayer = false;
    private Transform playerTransform;
    public float distance;


    //attacks
    public GameObject enemyAttack_01Prefab; // prefab of enemy attack

    void Start()
    {
        health = maxHealth;

    }

    void FixedUpdate()
    {

        enemySight();

        //just need movement here
    }


    void enemySight()
    {


        // Cast ray to the left
        Vector3 raycastDirection = Vector3.left;
        RaycastHit hitInfo;
        Vector3 raycastOrigin = transform.position;

        bool playerInSight = false; //to check if player is in sight
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hitInfo, raycastDistance))
        {
            // Check if the raycast hits a player
            if (hitInfo.collider.CompareTag("Player"))
            {
                // Follow the player
                followingPlayer = true;
                playerTransform = hitInfo.collider.transform;
                playerInSight = true; // set playerInSight to true if player is hit by the raycast
            }
        }
        // Draw a ray for visualization
        Debug.DrawRay(raycastOrigin, raycastDirection * raycastDistance, Color.red);

        //Cast ray to the right
        raycastDirection = Vector3.right;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hitInfo, raycastDistance))
        {
            // Check if the raycast hits a player
            if (hitInfo.collider.CompareTag("Player"))
            {
                // Follow the player
                followingPlayer = true;
                playerTransform = hitInfo.collider.transform;
                playerInSight = true; // set playerInSight to true if player is hit by the raycast
            }
        }
        // Draw a ray for visualization
        Debug.DrawRay(raycastOrigin, raycastDirection * raycastDistance, Color.red);

        if (followingPlayer && playerInSight) // only follow player if followingPlayer is true and player is in sight
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Cast ray towards player to check if player is still in line of sight
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            if (Physics.Raycast(transform.position, directionToPlayer, out hitInfo, raycastDistance))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    // Player is still in line of sight
                    followingPlayer = true;
                    playerInSight = true;
                }
                else
                {
                    // Player is not in line of sight, stop following
                    followingPlayer = false;
                    playerInSight = false;
                }
            }
            else
            {
                // Player is not in line of sight, stop following
                followingPlayer = false;
                playerInSight = false;
            }
        }
    }
}

