using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    public float force = 10f;
    // Possible values: "x", "y" and "-x", "-y"
    public string direction = "x";

    void Start()
    {
        // Ensure the GameObject has a 2D collider and is set as a trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone
        if (other.gameObject == player)
        {
            // Teleport the player to the target location
            player.transform.position = teleportTarget.position;
            Debug.Log("Teleporting player");
            // Apply force to the player in the specified direction
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("Applying force");
                switch (direction)
                {
                    case "x":
                        rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                        break;
                    case "y":
                        
                        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                        break;
                    case "-x":
                        rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                        break;
                    
                    case "-y":
                        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
                        break;
                }
            }

            
        }
    }
}