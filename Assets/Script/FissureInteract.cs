using UnityEngine;

public class FissureInteract : MonoBehaviour
{
    public GameObject keyBind;
    public ZoomEffectTopDown zoomScript;
    public AnimationManager animManScript;
    private bool playerHere = false;
    private bool once = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            keyBind.SetActive(true);
            playerHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            keyBind.SetActive(false);
            playerHere = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && zoomScript.mini == true && once == true){
            once = false;
            animManScript.index10();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHere){
            zoomScript.Mini();
        }
    }
}
