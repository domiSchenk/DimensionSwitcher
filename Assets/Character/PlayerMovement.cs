using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private float Move;

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;



    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(Move * speed, rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jump * 10));
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0f, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        return false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
