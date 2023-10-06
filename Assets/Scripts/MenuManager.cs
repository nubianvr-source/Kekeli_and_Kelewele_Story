using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void OpenMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
}
