using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsManager : MonoBehaviour
{
    public void Door1()
    {
        SceneManager.LoadScene("Scene_Mini_Dossier 1");
    }

    public void Door3()
    {
        SceneManager.LoadScene("CoffreFort");
    }
}
