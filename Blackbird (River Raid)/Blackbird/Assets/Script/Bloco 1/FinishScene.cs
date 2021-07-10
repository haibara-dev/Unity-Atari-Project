using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScene : MonoBehaviour
{
    public void OnNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Finish");
    }
}
