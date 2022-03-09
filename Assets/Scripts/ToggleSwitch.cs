using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
{

    public GameObject btnSlider;
    [SerializeField]private Transform _onPosition;
    [SerializeField]private Transform _offPosition;
    private Image _knob;

    private bool switchValue;
    
    
    // Start is called before the first frame update
    void Start()
    {
        switchValue = true;
        _knob = btnSlider.GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnAnimate(Transform endPos)
    {
        btnSlider.transform.DOMove(endPos.position, 0.25f);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Switch();
    }

    private void Switch()
    {
        if (switchValue)
            
        {
            BtnAnimate(_offPosition);
            _knob.DOColor(new Color(189f/255f,186f/255f,197f/255f,1), 0.25f);
            switchValue = false;
        }
        else
        {
            BtnAnimate(_onPosition);
            _knob.DOColor(new Color(37f/255f, 48f/255f, 82f/255f, 1), 0.25f);
            switchValue = true;
        }
    }


}
