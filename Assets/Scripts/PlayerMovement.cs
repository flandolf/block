using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float stompForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private readonly float _groundCheckRadius = 0.5f;
    private bool _canDoubleJump;
    private bool _isGrounded;
    private float _moveInput;
    public bool onEffect = false;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, _groundCheckRadius, groundLayer);

        // If the player is grounded, reset canDoubleJump
        if (_isGrounded) _canDoubleJump = true;

        // Get horizontal movement input
        _moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveInput * moveSpeed, _rb.velocity.y);

        // Jump if the player presses the jump button and is grounded
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            }
            else if (_canDoubleJump) // Perform double jump if the player is in the air and canDoubleJump is true
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                _canDoubleJump = false;
            }
        }

        // Stomp if the player presses the "S" key and is not grounded
        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow) && !_isGrounded))
            _rb.velocity = new Vector2(0, -stompForce);

        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (other.CompareTag("Finish")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}