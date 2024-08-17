using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator myAnimator;
    public int index = 0;
    private List<string> functionNames = new List<string> { "index1", "index2", "index3" };

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        AudioManager.instance.Play("Background");
        myAnimator.SetTrigger("1");
        index += 1;
        string methodName = functionNames[index-1];
        Invoke(methodName, 2f); 
    }

    public void index1()
    {
        Debug.Log("1");
        AudioManager.instance.Play("Jump");
        index += 1;
        string methodName = functionNames[index];
        Invoke(methodName, 3f); 
    }

    public void index2()
    {
        myAnimator.SetTrigger("1");
    } 

    public void index3()
    {
        Debug.Log("Executing index3");
        // Code spécifique à index3
    }
}
