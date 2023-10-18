using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintManagerScript : MonoBehaviour
{

    public Color[] colorList;

    public Color currentColor;

    public int currentColorIndex;

    public PaintBrushColorBtn btnPrefab;

    public PaintBrushColorBtn Eraser;

    public Vector2 buttonSize;

    public GameObject paintBrushBtnPanel;
    
    private List<PaintBrushColorBtn> _paintBrushColorBtns = new List<PaintBrushColorBtn>();
    
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        SetPaintBrushButtons();
        SetBrushColor(0);
    }

    private void SetPaintBrushButtons()
    {
        foreach (var t in colorList)
        {
            if (t.ToString() == "RGBA(1.000, 1.000, 1.000, 1.000)")
            {
                var eraser = Instantiate(Eraser, new Vector2(0, 0), quaternion.identity, paintBrushBtnPanel.transform);
                eraser.PaintManager = this;
                _paintBrushColorBtns.Add(eraser);
            }
            else
            {
                var paintBtn = Instantiate(btnPrefab, new Vector2(0, 0), quaternion.identity, paintBrushBtnPanel.transform);
                paintBtn.btnRectTransform.sizeDelta = buttonSize;
                //paintBtn.imageColor.color = t;
                if(paintBtn.bandColor != null)
                {
                    paintBtn.bandColor.color = t;
                }
                paintBtn.PaintManager = this;
                _paintBrushColorBtns.Add(paintBtn);
            }
        }
        
    }

    public void SetBrushColor(int index)
    {
        foreach (var paintBrushColorBtn in _paintBrushColorBtns)
        {
            paintBrushColorBtn.btnRectTransform.sizeDelta = buttonSize;
            paintBrushColorBtn.btnRectTransform.localScale = new Vector2(0.81439f, 0.81439f);  // sets the other brushes to their original size
        }

        LeanTween.scale(_paintBrushColorBtns[index].btnRectTransform, Vector3.one, 0.5f).setEaseOutBounce();
        //_paintBrushColorBtns[index].btnRectTransform.localScale = new Vector2(1,1);
        currentColorIndex = index;
        currentColor = colorList[currentColorIndex];
        print(currentColorIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;
            var ray = _camera.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(ray, -Vector2.up,200f);
            {
                if (hit.transform.CompareTag("ColorSpace"))
                {
                    if (hit.transform.gameObject.TryGetComponent(out SpritePaintRipple hitObject))
                    {
                        hitObject.StartRipple(hit.point, currentColor);
                    }
                }
                else
                {
                    Debug.Log("Nothing Found");
                }

            }
        }
    }
}

