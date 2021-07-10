using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    public void OnFinishButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
