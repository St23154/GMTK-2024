using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    private float realSpeed;
    private bool random;
    private ZoomEffectTopDown zoomScript;
    Rigidbody2D rb;
    private Animator myAnimator;
    Vector2 movement;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        zoomScript = GetComponent<ZoomEffectTopDown>();
    }

    void FixedUpdate()
    {
        if (zoomScript.canMove)
        {
            if (zoomScript.mini)
            {
                realSpeed = movSpeed * 0.03f;
            }else{
                realSpeed = movSpeed;
            }
            
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            myAnimator.SetFloat("y", moveY);
            myAnimator.SetFloat("x", moveX);
            
            movement = new Vector2(moveX, moveY);
            
            if (moveX == 0 && moveY == 0){
                myAnimator.SetBool("Idle", true);
                if (random){
                    random = false;
                    if (Random.Range(0,4) == 1){
                        Debug.Log("twist");
                        myAnimator.SetTrigger("Twist");
                    }
                }
            }else{
                myAnimator.SetBool("Idle", false);
                random = true;
            }
            
            if (movement.magnitude > 1){
                movement.Normalize();
            }

            rb.velocity = movement * realSpeed;
        }else{
            rb.velocity = Vector2.zero;
        }
    }
}
