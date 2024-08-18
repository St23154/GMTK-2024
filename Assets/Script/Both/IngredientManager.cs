using UnityEngine.SceneManagement;
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
            if (CollectedIngredients >= 4){
                CollectedIngredients = 4;
                EndGame();
            }
        }
    }

    void EndGame(){
        SceneManager.LoadScene("EndScene");
    }
}
