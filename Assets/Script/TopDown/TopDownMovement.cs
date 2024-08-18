using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    private float realSpeed;
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
            
            if (movement.magnitude > 1){
                movement.Normalize();
            }

            rb.velocity = movement * realSpeed;
        }else{
            rb.velocity = Vector2.zero;
        }
    }
}
