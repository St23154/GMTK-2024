using UnityEngine;

public class ShrinkAnimation : MonoBehaviour
{
    public bool mini = false;
    public float speed = 2f;
    public float posDown = 1;
    public Vector3 targetScale = new Vector3(0.001f, 0.001f, 0.001f);
    private Vector3 originalScale;
    private Vector3 originalPos;
    private Vector3 targetPos;

    void Start()
    {
        originalScale = transform.localScale;
        originalPos = transform.position;
        targetPos = transform.position;
    }

    void Update()
    {
        if (mini){
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos , speed * Time.deltaTime);
        }else{
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos , speed * Time.deltaTime);
        }
    }

    public void Mini()
    {
        if (mini == true){
            Debug.Log("tu est déjà mini");
        }else{
            mini = true;
            targetPos = new Vector3(transform.position.x, transform.position.y - posDown, transform.position.z);
        }
    }

    public void Grand()
    {
        if (mini == false){
            Debug.Log("tu est déjà grand");
        }else{
            mini = false;
            targetPos = new Vector3(transform.position.x, transform.position.y + posDown, transform.position.z);
        }       
    }
}

