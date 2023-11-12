using UnityEngine;

public class PlayerController : MonoBehaviour
{//class
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpingPower = 10f;
    [SerializeField] float groundDetectionRad = 0.1f;


    private void Awake()
    {
        
    }//awake

    private void Start()
    {

    }//start

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerJump();
        }
    }//update

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundDetectionRad, groundLayer);
    }//isGrounded

    private void playerJump()
    {
       _rigidbody.velocity = new Vector2(0, jumpingPower);
    }//playerJump

}//class
