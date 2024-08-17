using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    private float realSpeed;
    private ZoomEffect zoomScript;
    Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        zoomScript = GetComponent<ZoomEffect>();
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
