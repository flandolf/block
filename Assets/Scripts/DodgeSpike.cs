using UnityEngine;

public class DodgeSpike : MonoBehaviour
{
    public GameObject player;
    public GameObject spike;
    
    public float fallSpeed = 5f;
    public float spawnHeight = 10f;
    public float spawnDelay = 1f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnSpike), 0f, spawnDelay);
    }

    void SpawnSpike()
    {
        GameObject s = Instantiate(spike, new Vector3(player.transform.position.x, spawnHeight, 0), Quaternion.identity);
        // Add a rigidbody to the spike
        Rigidbody2D rb = s.AddComponent<Rigidbody2D>();
        // Set the gravity scale of the spike
        rb.gravityScale = fallSpeed;
        s.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    
    private void Update()
    {
        if (player.transform.position.y > spawnHeight)
        {
            spawnHeight = player.transform.position.y + 10;
        }
    }
}