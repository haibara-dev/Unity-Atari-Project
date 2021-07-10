using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public void OnNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase3");
    }
}
