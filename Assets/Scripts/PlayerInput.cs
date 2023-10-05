using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCastToCard();
    }

    private void RayCastToCard()
    {
        if (GameManager.instance.gameIsPaused) return;
            if (Input.GetMouseButtonDown(0) && !GameManager.instance.PickFull())
        {
            RaycastHit hit;
            //Not 100% sure on if this will work on mobile yet
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.TryGetComponent(out Card hitObject))
                {
                    hitObject.FlipOpen(true);
                    GameManager.instance.AddCardToPickedList(hitObject);
                    GameManager.instance.AddCardTurned();
                }

            }

        }
    }

}
