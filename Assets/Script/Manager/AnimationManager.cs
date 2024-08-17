using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator myAnimator;
    public int index = 0;
    private List<string> functionNames = new List<string> { "index1", "index2", "index3", "index4" };
    public List<GameObject> dialogueBoxes;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        AudioManager.instance.Play("Background");
        myAnimator.SetTrigger("1");
        string methodName = functionNames[index];
        Invoke(methodName, 2f); 
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
        AudioManager.instance.Play("Jump");
        NextIndex(3f);
    } 

    public void index3()
    {

    }
}
