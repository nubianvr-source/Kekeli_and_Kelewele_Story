using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class StoryManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ExitGame(string stringValue);
    public static StoryManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void ExitStory()
    {
    #if UNITY_WEBGL == true && UNITY_EDITOR == false
    ExitGame ("exitGame");
    #endif
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
