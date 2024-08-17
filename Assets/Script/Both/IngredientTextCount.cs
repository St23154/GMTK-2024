using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientTextCount : MonoBehaviour
{
    private TextMeshProUGUI TextMesh;
    private int LastSeenInt;

    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
        TextMesh.text = $"{IngredientManager.CollectedIngredients} / 4";
        LastSeenInt = IngredientManager.CollectedIngredients;
    }

    // Update is called once per frame
    void Update()
    {
        if (IngredientManager.CollectedIngredients != LastSeenInt) {
            TextMesh.text = $"{IngredientManager.CollectedIngredients} / 4";
            LastSeenInt = IngredientManager.CollectedIngredients;
        }
        
    }
}
