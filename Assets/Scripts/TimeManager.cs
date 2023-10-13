using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeRemaining = 60;
    public Image filledArrowImage;
    private float _tempTimeRemaining;

    public TextMeshProUGUI timerText = null;
    // Start is called before the first frame update
    void Start()
    {
       
        _tempTimeRemaining = timeRemaining;
        filledArrowImage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GetIsTimerRunning()) return;
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            filledArrowImage.fillAmount = (1f/ _tempTimeRemaining) * timeRemaining;
           timerText.text = ((int)timeRemaining).ToString();
        }
        else
        {
            Debug.Log("Timer has ended");
            GameManager.instance.SetIsTimerRunning(false);
            GameManager.instance.UiSystem.SwitchScreens(GameManager.instance.loseScreen);
        }
    }
}
