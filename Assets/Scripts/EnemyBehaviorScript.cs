    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyBehaviorScript : MonoBehaviour
    {
        //enemy stats
    private float health;
    public float maxHealth;

        //movements
    public float speed; //enemy movement speed
    public float distance; //distance to move  
    private Vector3 startPos;
    private bool isFacingLeft;

        //attacks
    public GameObject enemyAttack_01Prefab; // prefab of enemy attack


    void Start()
    {
       health = maxHealth;
       startPos = transform.position; //starting Position
    }

    void Update()
    {

     float newPosition = Mathf.Sin(Time.time * speed) * distance;
     // Set the position of the object to the new position
     transform.position = startPos + new Vector3(newPosition, 0f, 0f);

        if (newPosition > 0 && isFacingLeft)
        {
            flip(); // Flip enemy to face right
        }
        else if (newPosition < 0 && !isFacingLeft)
        {
            flip(); // Flip enemy to face left
        }
    }
    
    void flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0f,180f,0f);
    }
    
    void attack()
    {
       
    }
}
