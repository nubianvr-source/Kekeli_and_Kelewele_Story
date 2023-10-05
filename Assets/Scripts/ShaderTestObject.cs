using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTestObject : MonoBehaviour
{
    public int rotateSpeed;

    private Material _material;

    private Color _previousColor;

    private Camera _camera;

    private struct ShaderPropertyIDs
    {
        public int _BaseColor;
        public int _RippleColor;
        public int _RippleCenter;
        public int _RippleStartTime;
    }

    private ShaderPropertyIDs _shaderPropNames;
        // Start is called before the first frame update
    void Start()
    {
        _shaderPropNames = new ShaderPropertyIDs()
        {
            _BaseColor = Shader.PropertyToID("_BaseColor"),
            _RippleColor = Shader.PropertyToID("_RippleColor"),
            _RippleCenter = Shader.PropertyToID("_RippleCenter"),
            _RippleStartTime = Shader.PropertyToID("_RippleStartTime"),
        };
        
        _material = GetComponent<MeshRenderer>().material;
        _camera = Camera.main;

        _previousColor = _material.GetColor(_shaderPropNames._BaseColor);
        _material.SetColor(_shaderPropNames._RippleColor, _previousColor);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * (Time.deltaTime* rotateSpeed));
        if (Input.GetMouseButtonDown(0))
        {
            ClickToRay();
        }
    }

    private void ClickToRay()
    {
        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, _camera.nearClipPlane));
        if (Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            StartRipple(hit.point);
        }
    }

    private void StartRipple(Vector3 hitInfoPoint)
    {
        Color rippleColor = Color.HSVToRGB(Random.value, 1, 1);
        _material.SetVector(_shaderPropNames._RippleCenter, hitInfoPoint);
        _material.SetFloat(_shaderPropNames._RippleStartTime, Time.time);
        _material.SetColor(_shaderPropNames._BaseColor, _previousColor);
        _material.SetColor(_shaderPropNames._RippleColor, rippleColor);

        _previousColor = rippleColor;
    }
}
