using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    static public int CollectedIngredients = 0;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player"){
            CollectedIngredients += 1;
            gameObject.SetActive(false);

            //JOUER LE SON CRUNCH

            Destroy(gameObject);
        }
    }
}
