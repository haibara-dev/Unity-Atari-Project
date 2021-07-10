using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void OnNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase2");
    }
}
