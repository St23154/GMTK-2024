using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        SceneManager.LoadScene("StoryBeginning");
    }

    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Back(){
    SceneManager.LoadScene("MainMenu");
}
}
