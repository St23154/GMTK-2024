using System.Collections.Generic;
using UnityEngine;

public class AnimationMainScene : MonoBehaviour
{
    private Animator myAnimator;
    public int index = 0;
    public GameObject mainChar;
    public GameObject Kamera;
    private List<string> functionNames = new List<string> { "index1", "index2", "index3", "index4", "index5", "index6", "index7", "index8", "index9" };
    public List<GameObject> dialogueBoxes;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("1");
        string methodName = functionNames[index];
        Invoke(methodName, 1.5f); 
        Kamera.GetComponent<CameraTopDown>().enabled = false;
        Kamera.GetComponent<Animator>().enabled = false;
        mainChar.GetComponent<PlayerCtrl>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = true;
    }

    public void NextIndex(float time)
    {
        index += 1;
        string methodName = functionNames[index];
        Invoke(methodName, time); 
    }

    public void index1()
    {
        myAnimator.SetTrigger("1");
        NextIndex(14f);
    }

    public void index2()
    {
        Kamera.GetComponent<CameraTopDown>().enabled = true;
        Kamera.GetComponent<Animator>().enabled = true;
        mainChar.GetComponent<PlayerCtrl>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = false;
    } 

    public void index3()
    {

    }

    public void index4()
    {

    }

    public void index5()
    {

    }

    public void index6()
    {

    }

    public void index7()
    {

    }

    public void index8()
    {

    }

    public void index9()
    {

    }
}
