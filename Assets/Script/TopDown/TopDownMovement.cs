using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed = 5f;
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
        if (zoomScript.mini){
            realSpeed = movSpeed * 0.03f;
        }else{
            realSpeed = movSpeed;
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        movement = new Vector2(moveX, moveY);

        rb.velocity = movement * realSpeed;
    }
}
