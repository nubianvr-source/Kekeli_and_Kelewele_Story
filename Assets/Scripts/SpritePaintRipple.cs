using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePaintRipple : MonoBehaviour
{
    private Material _material;

    private Color _previousColor;

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
        
        _material = GetComponent<SpriteRenderer>().material;
        _previousColor = _material.GetColor(_shaderPropNames._BaseColor);
        _material.SetColor(_shaderPropNames._RippleColor, _previousColor);
    }
    
    public void StartRipple(Vector3 hitInfoPoint, Color colorVal)
    {
        Color rippleColor = colorVal;
        _material.SetVector(_shaderPropNames._RippleCenter, hitInfoPoint);
        _material.SetFloat(_shaderPropNames._RippleStartTime, Time.time);
        _material.SetColor(_shaderPropNames._BaseColor, _previousColor);
        _material.SetColor(_shaderPropNames._RippleColor, rippleColor);

        _previousColor = rippleColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
