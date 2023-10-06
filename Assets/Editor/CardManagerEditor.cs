using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardManager))]
public class CardManagerEditor : Editor
{
  private SerializedObject manager;
  private SerializedProperty _pairAmount;
  private SerializedProperty _width;
  private SerializedProperty _height;
  private SerializedProperty _spriteArray;

  private int _spriteAmount;
  private float _w, _h;
  
  private void OnEnable()
  {
    manager = new SerializedObject(target);
    _pairAmount = manager.FindProperty("pairAmount");
    _width = manager.FindProperty("width");
    _height = manager.FindProperty("height");
    _spriteArray = manager.FindProperty("spritesArray");
    _spriteAmount = _spriteArray.arraySize;
  }

  public override void OnInspectorGUI()
  {
    manager.Update();

    EditorGUILayout.BeginVertical(GUI.skin.box);
    GUI.enabled = false;
    EditorGUILayout.PropertyField(_pairAmount);
    GUI.enabled = true;
    EditorGUILayout.PropertyField(_width);
    EditorGUILayout.PropertyField(_height);

    float tmp = _width.intValue * (float)_height.intValue / 2;
    _pairAmount.intValue = (int) Mathf.Ceil(tmp);
    if (_pairAmount.intValue > _spriteAmount)
    {
      EditorGUILayout.HelpBox("Too Many Card Pairs over the amount of sprites in the Sprite Array", MessageType.Error);
    }

    if (_width.intValue < 0)
    {
      _width.intValue = 0;
    }
    
    if (_height.intValue < 0)
    {
      _height.intValue = 0;
    }

    EditorGUILayout.EndVertical();
    manager.ApplyModifiedProperties();
    DrawDefaultInspector();
  }
}
