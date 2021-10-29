using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{

    public GameObject[] pages;

    void Awake()
    {
        foreach (var i in pages)
        {
            i.SetActive(true);
        }
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
