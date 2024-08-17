using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SIMPLE_PLayermovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    private float realSpeed;
    public float jumpingPower = 16f;
    private float realJumpingPower;

    private bool isFacingRight = true;
    private bool canMove = true;

    private ZoomEffect zoom;
    private Animator myAnimator;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        zoom = GetComponent<ZoomEffect>();
        myAnimator = GetComponent<Animator>();
        realSpeed = speed; 
        realJumpingPower = jumpingPower;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (zoom.canMove){
            if(zoom.mini){
                realJumpingPower = jumpingPower * 0.3f;
            }else {
                realJumpingPower = jumpingPower;
            }

            if (Input.GetButtonDown("Jump") && IsGrounded()){
                rb.velocity = new Vector2(rb.velocity.x, realJumpingPower);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }



    private void FixedUpdate()
    {
        if (zoom.canMove){
            if(zoom.mini){
                realSpeed = speed * 0.1f;
            }else{
                realSpeed = speed;
            }
            rb.velocity = new Vector2(horizontal * realSpeed, rb.velocity.y);
            if(horizontal != 0){
                myAnimator.SetBool("IsMoving", true);
            }else{
                myAnimator.SetBool("IsMoving", false);
            }
        }else{
            myAnimator.SetBool("IsMoving", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
			Debug.Log("azerty");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}