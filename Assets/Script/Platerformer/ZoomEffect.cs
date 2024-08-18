using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

public class ZoomEffect : MonoBehaviour
{
    public float scaleFactor = 0.001f;
    public float minSize = 0.1f;
    public float maxSize = 3.0f;
    static public float potionTall = 100f;
    static public float potionSmall = 100f;
    static public float maxTall;
    static public float maxSmall;
    static public Image TallBarFill;
    static public Image SmallBarFill;
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

    void FixedUpdate()
    {
    
        Vector3 currentScale = transform.localScale;

        if (Input.GetMouseButton(1))
        {
            if (currentScale.x > minSize && potionSmall > 0)
            {
                UpdateSmallPotionUI(0.5f);
                jumpMultiplier += 0.01f;
                ActivateParticles();
                float newScale = Mathf.Max(currentScale.x - scaleFactor * sizeChangeSpeed*0.05f, minSize);
                currentScale = new Vector3(newScale, newScale, newScale);
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
                UpdateTallPotionUI(0.5f);
                jumpMultiplier -= 0.01f;
                ActivateParticles();
                Debug.Log(Time.deltaTime);
                float newScale = currentScale.x + scaleFactor * sizeChangeSpeed*0.05f;
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

    static public void UpdateTallPotionUI(float amountToDecrease)
    {
        potionTall -= amountToDecrease;
        if(potionTall < 0){ potionTall = 0; }
        if(TallBarFill != null){ TallBarFill.fillAmount = potionTall/maxTall; }
    }

    static public void UpdateSmallPotionUI(float amountToDecrease)
    {
        potionSmall -= amountToDecrease;
        if(potionSmall < 0){ potionSmall = 0; }
        if(SmallBarFill != null){ SmallBarFill.fillAmount = potionSmall/maxSmall; }     
    }

}
