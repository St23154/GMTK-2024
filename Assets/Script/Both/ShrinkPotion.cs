using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPotion : MonoBehaviour
{
    private ZoomEffect ZoomScript;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player"){
            ZoomScript = collision2D.gameObject.GetComponent<ZoomEffect>();
            ZoomScript.UpdateSmallPotionUI(-33.3f);
            gameObject.SetActive(false);

            //JOUER LE SON POTION

            Destroy(gameObject);
        }
    }
}
