using UnityEngine;

public class ShrinkAnimation : MonoBehaviour
{
    public bool mini = false;
    public float speed = 2f;
    public Vector3 targetScale = new Vector3(0.001f, 0.001f, 0.001f);

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (mini){
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
        }
        else{
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, speed * Time.deltaTime);
        }
    }
}

