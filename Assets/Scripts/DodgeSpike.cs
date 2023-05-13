using UnityEngine;

public class DodgeSpike : MonoBehaviour
{
    public GameObject player;
    public GameObject spike;
    public GameObject ground;

    public float fallSpeed = 5f;
    public float spawnHeight = 10f;
    public float spawnDelay = 1f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnSpike), 0f, spawnDelay);
        InvokeRepeating(nameof(SpawnGround), 0f, spawnDelay);
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

    void SpawnGround()
    {
        // Spawn ground under the player
        GameObject g=  Instantiate(ground, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
        WaitForSeconds wait = new WaitForSeconds(0.4f);
        Rigidbody2D rb = g.AddComponent<Rigidbody2D>();
        rb.gravityScale = fallSpeed;
        g.transform.localScale = new Vector3(1, 0.1f, 1);
        
    }

    private void Update()
    {
        if (player.transform.position.y > spawnHeight)
        {
            spawnHeight = player.transform.position.y + 10;
        }
    }
}