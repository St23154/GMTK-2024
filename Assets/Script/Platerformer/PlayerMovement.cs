using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Playermovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    private float realSpeed;
    public float jumpingPower = 11f;
    private float realJumpingPower;

    private bool isFacingRight = true;
    private bool random = false;

    private ZoomEffect zoom;
    private Animator myAnimator;
     public GameObject objectToHide;
     public GameObject objectToShow;
     public GameObject toile;

    [SerializeField] public Vector2 _groundCheckSize;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float coyoteTime = 0.2f; // Time after leaving ground where jump is still allowed
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f; // Time window where a jump input is stored
    private float jumpBufferCounter;




    void Start()
    {
        _groundCheckSize = new Vector2(1.4f, 0.03f);
        jumpingPower = 11f;
        zoom = GetComponent<ZoomEffect>();
        myAnimator = GetComponent<Animator>();
        realSpeed = speed; 
        realJumpingPower = jumpingPower;
        objectToShow.SetActive(false);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (zoom.canMove){
            // if(zoom.mini){
                realJumpingPower = jumpingPower * zoom.jumpMultiplier;
            // }else {
            //     realJumpingPower = jumpingPower;
            // }

            if (Input.GetButtonDown("Jump") && IsGrounded()){
                rb.velocity = new Vector2(rb.velocity.x, realJumpingPower);
            }
        }

        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
         }

       
         // Coyote time handling
            if (IsGrounded())
            {
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }

            // Jump buffer handling
            if (Input.GetButtonDown("Jump"))
            {
                jumpBufferCounter = jumpBufferTime;
            }
            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }

            // Jump if within coyote time or buffered jump
            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, realJumpingPower);
                jumpBufferCounter = 0f; // Reset jump buffer
            }

            // Smooth jump cut-off
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.7f);
            }

        Flip(); 
    }

 private void OnDrawGizmos()
    {

            // Set the color of the gizmo
            Gizmos.color = Color.red;

            // Draw a wireframe cube at the groundCheck position with the specified size
            Gizmos.DrawWireCube(groundCheck.position, _groundCheckSize);
        }
    


    private void FixedUpdate()
    {
        if (zoom.canMove){
            if(zoom.mini){
                realSpeed = speed * 0.1f;
            //rb.gravityScale = 1f;
            }else{
                realSpeed = speed;
                rb.gravityScale = IsGrounded() ? 1f : 2.5f; // Increased gravity when not grounded 
            }
            rb.velocity = new Vector2(horizontal * realSpeed, rb.velocity.y);
            if(horizontal != 0){
                myAnimator.SetBool("IsMoving", true);
                random = true;
            }else{
                myAnimator.SetBool("IsMoving", false);
                if (random){
                    random = false;
                    if (Random.Range(0,8) == 3){
                        myAnimator.SetTrigger("Twist");
                    }
                }
            }
        }else{
            myAnimator.SetBool("IsMoving", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, _groundCheckSize, 0, groundLayer);
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
        if (other.gameObject.CompareTag("Enemy")){
            StartCoroutine(reloadScene());
            Die();
        }

        if (other.gameObject.CompareTag("document")){
            StartCoroutine(reloadScene());
            Die();
        }

        if (other.gameObject.CompareTag("troudstuyaux") && zoom.jumpMultiplier > 1.1){
            SceneManager.LoadScene("Scene_Dossier");
        }
        if (other.gameObject.CompareTag("Ingredient")){
            StartCoroutine(Changement_DE_Scene());
        }

    }
    IEnumerator Changement_DE_Scene(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Center");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("tallPotion")){
            if (zoom.mini){
                Destroy(other.gameObject);
                //zoom.Grand();
            }
        }

        if (other.gameObject.CompareTag("sortie_tuyaux")){
             objectToHide.SetActive(false);
             objectToShow.SetActive(true);
        }
    }


    public void Die()
    {
        AudioManager.instance.Play("Death");
        myAnimator.SetTrigger("Die");
        zoom.canMove = false;
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Collider2D cl = gameObject.GetComponent<Collider2D>();
        cl.isTrigger = true;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
