using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Start() {
        Time.timeScale = 1;
    }
    public void OpenMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
}
