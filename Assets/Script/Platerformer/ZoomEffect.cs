using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZoomEffect : MonoBehaviour
{
    public bool mini = false;
    public bool isAnimating = false;
    public float speed = 2f;
    public float posDown = 1;

    public Animator myCameraAnimator;
    public Vector3 targetScale = new Vector3(0.001f, 0.001f, 0.001f);
    private Vector3 originalScale;
    private Vector3 targetPos;
    public List<GameObject> particles;
    private float closeEnough = 0.01f; // Valeur pour définir si on est "suffisamment proche"

    void Start()
    {
        originalScale = transform.localScale;
        targetPos = transform.position;
    }

    void Update()
    {
        if (isAnimating)
            if (mini)
            {
                ActivateParticles();
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
                if (Vector3.Distance(transform.localScale, targetScale) < closeEnough){
                    StartCoroutine(destroyParticles());
                    transform.position = targetPos;
                    transform.localScale = targetScale;
                    isAnimating = false;
                }
            
            }else{
                transform.localScale = Vector3.Lerp(transform.localScale, originalScale, speed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
                if (Vector3.Distance(transform.localScale, originalScale) < closeEnough){
                    transform.position = targetPos;
                    isAnimating = false;
                    transform.localScale = originalScale;
                }
            }
    }

    public void Mini()
    {
        if (mini == true){
            Debug.Log("tu est déjà mini");
        }else{
            mini = true;
            targetPos = new Vector3(transform.position.x, transform.position.y - posDown, transform.position.z);
            myCameraAnimator.SetTrigger("Zoom");
            isAnimating = true;
        }
    }

    public void Grand()
    {
        if (mini == false){
            Debug.Log("tu est déjà grand");
        }else{
            mini = false;
            targetPos = new Vector3(transform.position.x, transform.position.y + posDown, transform.position.z);
            myCameraAnimator.SetTrigger("UnZoom");
            isAnimating = true;
        }
    }

    
    void ActivateParticles()
    {
        foreach (GameObject obj in particles)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    void DesactivateParticles()
    {
        foreach (GameObject obj in particles)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    IEnumerator destroyParticles()
    {
        yield return new WaitForSeconds(5);
        DesactivateParticles();
    }
}
