using System;
using System.Collections;
using System.Collections.Generic;
using NubianVR.UI;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   private bool _pickFull = false;

   private int _pairs;

   private int _pairCounter;

   private int _cardTurnedCount; 
   
   private List<TwoDimensionCardScript> pickedCards = new List<TwoDimensionCardScript>();

   public float delayTime = 0.25f;

   public bool hideMatches;
   
   private bool _isTimerRunning = false;

   public bool gameIsPaused;

   public Animator PausePanel;

    [Header("Timer")]

    public int time;
    public TextMeshProUGUI timerText = null;

   
   [Header("UI System References")]
   public UI_System UiSystem;

   public UI_Screen winScreen;

   public UI_Screen loseScreen;

   private void Start()
   {
      _cardTurnedCount = 0;
   }

    private void Update()
    {
        Timer();
    }
    public bool GetIsTimerRunning()
   {
      return _isTimerRunning;
   }

   public void SetIsTimerRunning(bool timerBool)
   {
      _isTimerRunning = timerBool;
   }

   public int GetTurnedCardsCount()
   {
      return _cardTurnedCount;
   }

   public void AddCardTurned()
   {
      _cardTurnedCount++;
   }

   private void Awake()
   {
      //if(instance != null) return;
      instance = this;
      //DontDestroyOnLoad(this);
   }

   public void AddCardToPickedList(TwoDimensionCardScript card)
   {
      pickedCards.Add(card);
      if (pickedCards.Count == 2)
      {
         _pickFull = true;
         StartCoroutine(CheckMatch());
      }
   }

   IEnumerator CheckMatch()
   {
      yield return new WaitForSeconds(delayTime);
      if (pickedCards[0].CardId() == pickedCards[1].CardId())
      {
         if (hideMatches)
         {
            pickedCards[0].gameObject.SetActive(false);
            pickedCards[1].gameObject.SetActive(false);
         }
         else
         {
            if(pickedCards[0].TryGetComponent(out BoxCollider2D collider0))
            {
               collider0.enabled = false;
            }
         
            if(pickedCards[1].TryGetComponent(out BoxCollider2D collider1))
            {
               collider1.enabled = false;
            }
         }
        
         _pairCounter++;
         CheckWin();
      }
      else
      {
         pickedCards[0].FlipClose();
         pickedCards[1].FlipClose();
         yield return new WaitForSeconds(delayTime);
      }
     
      //Clean up
      _pickFull = false;
      pickedCards.Clear();
   }

   public void SetTimerRunningToTrue()
   {
      _isTimerRunning = true;
   }

   void CheckWin()
   {
      if (_pairs == _pairCounter)
      {
         //Player Win
         Debug.Log("Player Win");
         _isTimerRunning = false;
         UiSystem.SwitchScreens(winScreen);
      }
   }

   public bool PickFull()
   {
      return _pickFull;
   }

   public void SetPairs(int pairAmount)
   {
      _pairs = pairAmount;
   }
   
   public void PauseGame()
   {
      Time.timeScale = 0.0f;
      AudioListener.pause = true;
      gameIsPaused = true;
       PausePanel.SetTrigger("Pause");
   }

   public void ResumeGame()
   {
      
      AudioListener.pause = false;
        PausePanel.SetTrigger("Resume");
        gameIsPaused = false;
        Time.timeScale = 1.0f;

    }

   public void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void LoadScene(int sceneIndex)
   {
      SceneManager.LoadScene(sceneIndex);
   }

    public void Timer()
    {
        time -= (int)Time.time;
        Debug.Log(time);
    }

    

}
