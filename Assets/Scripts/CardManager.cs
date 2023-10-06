using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    [HideInInspector]public int pairAmount;

    //public Vector3 playFieldCenter;

    public Sprite[] spritesArray;

    private float _xOffset = 2.0f;

    private float _zOffset = 2.2f;

    public TwoDimensionCardScript cardPrefab;

    public GameObject cardPrefabParent;
    
    private List<TwoDimensionCardScript> _cardDeck = new List<TwoDimensionCardScript>();

    [HideInInspector]public int width;
    
    [HideInInspector]public int height;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetPairs(pairAmount);
        //CreatePlayField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlayField()
    {
        for (int i = 0; i < pairAmount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                //Vector3 pos = Vector3.zero;
                TwoDimensionCardScript newCard = Instantiate(cardPrefab,cardPrefabParent.transform);
                newCard.SetCard(i,spritesArray[i]);
                _cardDeck.Add(newCard);
            }
        }
        //Shuffle Cards
        for (int i = 0; i < _cardDeck.Count; i++)
        {
            int index = Random.Range(0, _cardDeck.Count);
            var temp = _cardDeck[i];
            _cardDeck[i] = _cardDeck[index];
            _cardDeck[index] = temp;
            _cardDeck[index].transform.SetSiblingIndex(index);
        }

        // int num = 0;
        // for (int x = 0; x < width; x++)
        // {
        //     for (int z = 0; z < height; z++)
        //     {
        //         Vector3 pos = new Vector3(x*_xOffset, 0, z*_zOffset);
        //         _cardDeck[num].transform.position = pos;
        //         num++;
        //     }
        //     
        // }
    }
    private void OnDrawGizmos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x*_xOffset, 0, z*_zOffset);
                Gizmos.DrawWireCube(pos,new Vector3(1.8f,0.1f,2.0f));
            }
            
        }
        //if (Selection.activeGameObject != gameObject) return;
            Gizmos.color = new Color(0.0f,0.0f,255.0f,0.5f);
            var size = new Vector3(width * 2, 0, height * 2.2f);
            var center = new Vector3(width-1,0,height-0.9f);
            Gizmos.DrawCube(center,size);

    }
}
