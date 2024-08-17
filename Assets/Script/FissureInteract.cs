using UnityEngine;

public class FissureInteract : MonoBehaviour
{
    public GameObject keyBind;
    public ZoomEffect zoomScript;
    private bool playerHere = false;

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
        if (other.gameObject.CompareTag("Player") && zoomScript.mini == true){
            LaunchNextScene();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHere){
            zoomScript.Mini();
        }
    }

    void LaunchNextScene()
    {
        Debug.Log("Next Scene");
    }
}
