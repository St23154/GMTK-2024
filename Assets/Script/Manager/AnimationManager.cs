using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator myAnimator;
    public int index = 0;
    public GameObject square;
    public GameObject prisonner;
    public GameObject mainChar;
    public GameObject Kamera;
    private List<string> functionNames = new List<string> { "index1", "index2", "index3", "index4", "index5", "index6", "index7", "index8", "index9" };
    public List<GameObject> dialogueBoxes;

    void Start()
    {
        prisonner.SetActive(true);
        square.SetActive(false);
        mainChar.SetActive(false);
        myAnimator = GetComponent<Animator>();
        AudioManager.instance.Play("Mysterious");
        myAnimator.SetTrigger("1");
        string methodName = functionNames[index];
        Invoke(methodName, 1.5f); 
    }

    public void NextIndex(float time)
    {
        index += 1;
        string methodName = functionNames[index];
        Invoke(methodName, time); 
    }

    public void index1()
    {
        dialogueBoxes[0].SetActive(true); 
    }

    public void index2()
    {
        AudioManager.instance.Play("Chaos");
        AudioManager.instance.Stop("Mysterious");
        myAnimator.SetTrigger("2");
        NextIndex(0f);
    } 

    public void index3()
    {
        dialogueBoxes[1].SetActive(true); 
    }

    public void index4()
    {
        AudioManager.instance.Play("Boss");
        AudioManager.instance.Stop("Chaos");
        myAnimator.SetTrigger("4"); 
        NextIndex(3.6f);
    }

    public void index5()
    {
        dialogueBoxes[2].SetActive(true);
    }

    public void index6()
    {
        myAnimator.SetTrigger("5");
        NextIndex(22f);
    }

    public void index7()
    {
        AudioManager.instance.Play("Chaos");
        AudioManager.instance.Stop("Boss");
        dialogueBoxes[3].SetActive(true);
    }

    public void index8()
    {
        Kamera.transform.position = new Vector3(-4f, 2f, -99);
        prisonner.SetActive(false);
        square.SetActive(true);
        mainChar.SetActive(true);
        myAnimator.SetTrigger("6");
        NextIndex(2.5f);
    }

    public void index9()
    {
        Destroy(square);
        Kamera.GetComponent<CameraTopDown>().enabled = true;
        mainChar.GetComponent<PlayerCtrl>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
