using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class IngredientProgressBar : MonoBehaviour
{
    private UnityEngine.UI.Image Image;
    private Sprite StateSprite;
    private int LastSeenInt;

    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<UnityEngine.UI.Image>();
        LastSeenInt = IngredientManager.CollectedIngredients;
    }

    // Update is called once per frame
    void Update()
    {
        if (IngredientManager.CollectedIngredients != LastSeenInt) {
            UpdateBottle();
            LastSeenInt = IngredientManager.CollectedIngredients;
        }
        
    }

    void UpdateBottle()
    {
        if (IngredientManager.CollectedIngredients <= 0) {
            StateSprite = Resources.Load<Sprite>("progressbar/progressbar_stage_0");
            Image.sprite = StateSprite;
        } else if (IngredientManager.CollectedIngredients == 1) {
            StateSprite = Resources.Load<Sprite>("progressbar/progressbar_stage_1");
            Image.sprite = StateSprite;
        } else if (IngredientManager.CollectedIngredients == 2) {
            StateSprite = Resources.Load<Sprite>("progressbar/progressbar_stage_2");
            Image.sprite = StateSprite;
        } else if (IngredientManager.CollectedIngredients == 3) {
            StateSprite = Resources.Load<Sprite>("progressbar/progressbar_stage_3");
            Image.sprite = StateSprite;
        } else {
            StateSprite = Resources.Load<Sprite>("progressbar/progressbar_stage_4");
            Image.sprite = StateSprite;
        }
    }
}


// COMMIT RESOURCES FOLDER & CE SCRIPT & LE PREFAB