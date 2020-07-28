using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
