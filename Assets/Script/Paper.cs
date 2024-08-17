using System.Collections;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public float scaleFactor = 1.5f; // Facteur de redimensionnement
    public float duration = 5f; // Durée en secondes pour un cycle complet (grossissement + rétrécissement)

    private Vector3 originalScale; // Taille d'origine de l'objet

    // Start est appelé avant la première mise à jour de frame
    void Start()
    {
        originalScale = transform.localScale; // Sauvegarder la taille d'origine
        StartCoroutine(ChangeScaleContinuously()); // Démarrer la coroutine pour changer la taille
    }

    // Coroutine pour changer la taille de manière continue
    IEnumerator ChangeScaleContinuously()
    {
        while (true)
        {
            // Grossir l'objet
            yield return ScaleOverTime(originalScale * scaleFactor, duration / 2);

            // Rétrécir l'objet
            yield return ScaleOverTime(originalScale, duration / 2);
        }
    }

    // Coroutine pour effectuer le changement de taille de manière fluide
    IEnumerator ScaleOverTime(Vector3 targetScale, float time)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // S'assurer que la taille finale est bien atteinte
    }
}
