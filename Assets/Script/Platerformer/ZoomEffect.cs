using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZoomEffect : MonoBehaviour
{
    // Variables to control size
    public float scaleFactor = 0.5f;  // The amount by which the size changes each time
    public float minSize = 0.1f;      // Minimum scale limit
    public float maxSize = 5.0f;      // Maximum scale limit
    public bool mini = false;
    public List<GameObject> particles;
   
    public bool canMove = true;
    public float sizeChangeSpeed = 1f;
    void Update()
    {
        // Get the current scale of the slime
        Vector3 currentScale = transform.localScale;

        // Decrease size when pressing the "S" key
        if (Input.GetKey(KeyCode.T))
        {
            // Ensure the slime doesn't shrink below the minimum size
            if (currentScale.x > minSize)
            {
                ActivateParticles();
                float newScale = Mathf.Max(currentScale.x - scaleFactor * sizeChangeSpeed * 1, minSize);
                Debug.Log(currentScale);
                currentScale = new Vector3(newScale, newScale, newScale);
                Debug.Log(currentScale);
                transform.localScale = currentScale;
            }

            else{
               StartCoroutine(destroyParticles());
            }
        }

        // Increase size when pressing the "W" key
        if (Input.GetKey(KeyCode.E))
        {
            // Ensure the slime doesn't grow beyond the maximum size
            if (currentScale.x < maxSize)
            {
                ActivateParticles();
                float newScale = currentScale.x + scaleFactor * sizeChangeSpeed * 1;
                currentScale = new Vector3(newScale, newScale, newScale);
                transform.localScale = currentScale;
            }
            
            else{
               StartCoroutine(destroyParticles());
            }
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
        Debug.Log("DDD");
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



// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// public class ZoomEffect : MonoBehaviour
// {
    // public bool mini = false;
    // public bool isAnimating = false;
    // public float speed = 2f;
    // public float posDown = 1;
    // public bool canMove = true;

    // public Animator myCameraAnimator;
    // public Vector2 targetScale = new Vector3(0.001f, 0.001f);
    // private Vector2 originalScale;
    // private Vector3 targetPos;
    // public List<GameObject> particles;
    // private float closeEnough = 0.01f; // Valeur pour définir si on est "suffisamment proche"

//     void Start()
//     {
//         originalScale = transform.localScale;
//         targetPos = transform.position;
//     }

//     void Update()
//     {
//         if (isAnimating){
//             if (mini)
//             {
//                 ActivateParticles();
//                 transform.localScale = Vector2.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
//                 transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
//                 if (Vector3.Distance(transform.localScale, targetScale) < closeEnough){
//                     StartCoroutine(destroyParticles());
//                     transform.position = targetPos;
//                     transform.localScale = targetScale;
//                     isAnimating = false;
//                     canMove = true;
//                 }
            
//             }else{
//                 transform.localScale = Vector2.Lerp(transform.localScale, originalScale, speed * Time.deltaTime);
//                 transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
//                 if (Vector3.Distance(transform.localScale, originalScale) < closeEnough){
//                     transform.position = targetPos;
//                     isAnimating = false;
//                     canMove = true;
//                     transform.localScale = originalScale;
//                 }
//             }
//         }
//     }

//     public void Mini()
//     {
//         if (mini == true){
//             Debug.Log("tu est déjà mini");
//         }else{
//             canMove = false;
//             mini = true;
//             targetPos = new Vector3(transform.position.x, transform.position.y - posDown, transform.position.z);
//             myCameraAnimator.SetTrigger("Zoom");
//             isAnimating = true;
//         }
//     }

//     public void Grand()
//     {
//         if (mini == false){
//             Debug.Log("tu est déjà grand");
//         }else{
//             canMove = false;
//             mini = false;
//             targetPos = new Vector3(transform.position.x, transform.position.y + posDown, transform.position.z);
//             myCameraAnimator.SetTrigger("UnZoom");
//             isAnimating = true;
//         }
//     }

    


//     public void MakeHimMove()
//     {
//         canMove = true;
//     }
// }
