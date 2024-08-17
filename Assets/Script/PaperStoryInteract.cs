using UnityEngine;

public class PaperStoryInteract : MonoBehaviour
{

    public GameObject keyBind;
    public GameObject paper;
    public ZoomEffect zoomScript;
    public GameObject fissure;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHere){
            zoomScript.canMove = false;
            fissure.SetActive(true);
            paper.SetActive(true);
            Destroy(gameObject);
        }
    }
}
