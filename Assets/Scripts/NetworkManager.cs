using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Feedback
{
   public int rating;
   public string feedback;
   public string date;
}

public class NetworkManager : MonoBehaviour
{
   [SerializeField] private string feedbackEndPoint = "https://isfeedbackserver.herokuapp.com/feedback";
   private int rating;
   [SerializeField] private TMP_InputField feedback;
   [FormerlySerializedAs("_errorMessage")] [SerializeField] private TMP_Text _alertMessage;
   [SerializeField] private Button submitButton;
   [SerializeField] private GameObject loadingScreen;
   [SerializeField] private GameObject confirmationScreen;
   [SerializeField] private GameObject errorHandlingScreen;
   [SerializeField] private GameObject loadingObject;
   [SerializeField] private TMP_Text errorText;
   [SerializeField]
   private RatingManager ratingManager;

   private CanvasGroup loadingScreenCanvasGroup;
   private CanvasGroup errorHandlingScreenCanvasGroup;

   private void Awake()
   {
      
      loadingScreenCanvasGroup = loadingScreen.GetComponent<CanvasGroup>();
      errorHandlingScreenCanvasGroup = errorHandlingScreen.GetComponent<CanvasGroup>();
      confirmationScreen.SetActive(false);
      
   }


   private void Start()
   {
      HideLoadingScreen();
   }

   public void SubmitRating()
   {
      rating = ratingManager._userRating;
      submitButton.interactable = false;
      if (ratingManager._userRating > 0)
      {
         submitButton.interactable = false;
         ShowLoadingScreen();
         StartCoroutine(TrySendRating());
      }
      else
      {
         _alertMessage.gameObject.SetActive(true);
         _alertMessage.gameObject.transform.DOShakePosition(0.75f, new Vector3(10f, 10f), 12, 90f);
         submitButton.interactable = true;
      }
   }

   private void ShowLoadingScreen()
   {
      loadingScreen.SetActive(true);
      loadingScreenCanvasGroup.DOFade(1, 0.75f);
      loadingObject.transform.DORotate(new Vector3(0, 0, 180), 1f).SetLoops(-1, LoopType.Incremental)
         .SetEase(Ease.Linear);
   }

   private void HideLoadingScreen()
   {
      loadingScreenCanvasGroup.DOFade(0, 0.75f);
      loadingScreen.SetActive(false);
      loadingObject.transform.DOKill();
   }

   private void ShowErrorMessageScreen()
   {
      errorHandlingScreen.SetActive(true);
      errorHandlingScreenCanvasGroup.DOFade(1, 0.75f);
   }

   public void HideErrorMessageScreen()
   {
      errorHandlingScreenCanvasGroup.DOFade(0, 0.75f);
      errorHandlingScreen.SetActive(false);
      submitButton.interactable = true;
   }

   private IEnumerator TrySendRating()
   {
      int newRating = rating;
      string newFeedback = feedback.text;
      
      
      WWWForm feedbackForm = new WWWForm();
      
      feedbackForm.AddField("rating", newRating);
      feedbackForm.AddField("feedback", newFeedback);
      
      UnityWebRequest request = UnityWebRequest.Post(feedbackEndPoint,feedbackForm);
      var handler = request.SendWebRequest();
      Debug.Log($"{newRating} : {newFeedback}");
      print(feedbackForm.data.Length);
      float startTime = 0.0f;
      while (!handler.isDone)
      {
         startTime += Time.deltaTime;
         if (startTime > 30.0f)
         {
            break;
         }

         yield return null;
      }

      if (request.result == UnityWebRequest.Result.Success)
      {
         if (request.responseCode == 200)
         {
            submitButton.interactable = true;
            var confirmationScreenCanvasGroup = confirmationScreen.GetComponent<CanvasGroup>();
            confirmationScreen.SetActive(true);
            HideLoadingScreen();
            confirmationScreenCanvasGroup.DOFade(1, 0.75f);
            Feedback submittedfeedback = JsonUtility.FromJson<Feedback>(request.downloadHandler.text);
            Debug.Log(submittedfeedback.rating + submittedfeedback.feedback);
         }
         else
         {
            errorText.text = "There was a problem submitting your rating! \n Please try again.";
            HideLoadingScreen();
            ShowErrorMessageScreen();
         }
      }
      else
      {
         errorText.text = "There was a problem connecting to the server! \n Please try again.";
         HideLoadingScreen();
         ShowErrorMessageScreen();
      }

      yield return null;
   }
}

