using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeRemaining = 10.0f;

    private float _tempTimeRemaining;

    public Image innerBar;
    // Start is called before the first frame update
    void Start()
    {
        innerBar.fillAmount = 1;
        _tempTimeRemaining = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GetIsTimerRunning()) return;
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            innerBar.fillAmount = timeRemaining / _tempTimeRemaining;
        }
        else
        {
            Debug.Log("Timer has ended");
            GameManager.instance.SetIsTimerRunning(false);
            GameManager.instance.UiSystem.SwitchScreens(GameManager.instance.loseScreen);
        }
    }
}
