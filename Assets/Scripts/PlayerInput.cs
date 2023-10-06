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
        //RayCastToCard();
    }
    
    

    /*private void RayCastToCard()
    {
        if (GameManager.instance.gameIsPaused) return;
            if (Input.GetMouseButtonDown(0) && !GameManager.instance.PickFull())
        {
            RaycastHit2D hit;
            Vector2 mousePosition = Input.mousePosition;
            Ray2D ray = Camera.main.ScreenToWorldPoint(mousePosition);

            if (Physics2D.Raycast(ray.origin, ray.direction, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.TryGetComponent<TwoDimensionCardScript>(out TwoDimensionCardScript hitObject))
                {
                    hitObject.FlipOpen();
                    GameManager.instance.AddCardToPickedList(hitObject);
                    GameManager.instance.AddCardTurned();
                }

            }

        }
    }*/

}
