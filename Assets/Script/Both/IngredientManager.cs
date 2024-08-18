using UnityEngine.SceneManagement;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    static public int CollectedIngredients = 0;
    private SpriteRenderer Sprout;

    void Start(){
        Sprout = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player"){
            if (Sprout.sprite.name.StartsWith("ingredient_cheese")) {
                CollectedIngredients = 1;
            } else if (Sprout.sprite.name.StartsWith("ingredient_cobweb")) { 
                CollectedIngredients = 2;
            } else if (Sprout.sprite.name.StartsWith("ingredient_drug")) { 
                CollectedIngredients = 3;
            } else if (Sprout.sprite.name.StartsWith("ingredient_gem")) {
                CollectedIngredients = 4;
            }
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
