using UnityEngine;

public class FissureInteract : MonoBehaviour
{
    public GameObject keyBind;
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

        }
    }
}
