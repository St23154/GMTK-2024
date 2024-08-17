using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Background");
    }

}
