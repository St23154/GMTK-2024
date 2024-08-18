using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ZoomEffect : MonoBehaviour
{
    public float scaleFactor = 0.001f;
    public float minSize = 0.1f;
    public float maxSize = 3.0f;
    public float potionTall = 100f;
    public float potionSmall = 100f;
    private float maxTall;
    private float maxSmall;
    public Image TallBarFill;
    public Image SmallBarFill;
    public bool mini = false;
    public List<GameObject> particles;
   
    public bool canMove = true;
    public float sizeChangeSpeed = 0.01f;
    public float jumpMultiplier = 1;

    void Start()
    {
        maxTall = potionTall;
        maxSmall = potionSmall;
    }

    void Update()
    {
        Vector3 currentScale = transform.localScale;

        if (Input.GetMouseButton(1))
        {
            if (currentScale.x > minSize && potionSmall > 0)
            {
                UpdateSmallPotionUI(1);
                jumpMultiplier += 0.01f;
                ActivateParticles();
                float newScale = Mathf.Max(currentScale.x - scaleFactor * sizeChangeSpeed*0.1f, minSize);
                Debug.Log(currentScale);
                currentScale = new Vector3(newScale, newScale, newScale);
                Debug.Log(currentScale);
                transform.localScale = currentScale;
            }

            else{
               StartCoroutine(destroyParticles());
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (currentScale.x < maxSize && potionTall>0)
            {
                UpdateTallPotionUI(1);
                jumpMultiplier -= 0.01f;
                ActivateParticles();
                float newScale = currentScale.x + scaleFactor * sizeChangeSpeed * 0.1f;
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

    public void UpdateTallPotionUI(float amountToDecrease)
    {
        potionTall -= amountToDecrease;
        if(potionTall < 0){ potionTall = 0; }
        TallBarFill.fillAmount = potionTall/maxTall;
    }

    public void UpdateSmallPotionUI(float amountToDecrease)
    {
        potionSmall -= amountToDecrease;
        if(potionSmall < 0){ potionSmall = 0; }
        SmallBarFill.fillAmount = potionSmall/maxSmall;        
    }

}
