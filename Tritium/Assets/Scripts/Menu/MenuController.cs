using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Company()
    {
        SceneManager.LoadScene("Company");
    }

    public void Deathmatch()
    {
        SceneManager.LoadScene("Deathmatch");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
