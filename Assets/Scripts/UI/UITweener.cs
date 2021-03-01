﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Animation Types
public enum AnimationType
{
    MoveX,
    MoveY,
    Move,
    MoveLocalX,
    MoveLocalY,
    MoveLocal,
    RotateX,
    RotateY,
    RotateZ,
    Rotate,
    RotateLocal,
    ScaleX,
    ScaleY,
    ScaleZ,
    Scale,
    Alpha,
    Color
}
#endregion
public class UITweener : MonoBehaviour
{
    // Change from public to private at final build
    public GameObject _objectToAnimate;
    public GameObject _objectToDisable;

    public AnimationType _animationType;
    public LeanTweenType _easeType;
    public float _duration;
    public float _delay;
    public bool _startPositionOffset;
    public float _floatFrom;
    public float _floatTo;
    public Vector3 _vectorFrom;
    public Vector3 _vectorTo;
    public Color _colorFrom;
    public Color _colorTo;

    public bool _loop;
    public bool _pingPong;
    public bool _showOnEnable;
    public bool _workOnDisable;
    public bool _useUnscaledTime;

    private LTDescr _tweenObject;
    private RectTransform _objRectTransform;
    private CanvasGroup _objCanvasGroup;
    private Color _objColor;

    private void OnEnable()
    {
        if(_showOnEnable)
        {
            Show();
        }
    }

    public void Show()
    {
        HandleTween();
    }

    private void HandleTween()
    {
        if(_objectToAnimate == null)
        {
            _objectToAnimate = gameObject;
        }
        if(_objectToDisable == null)
        {
            _objectToDisable = gameObject;
        }

        switch(_animationType)
        {
            case AnimationType.MoveX:
                MoveX();
                break;
            case AnimationType.MoveY:
                MoveY();
                break;
            case AnimationType.Move:
                Move();
                break;
            case AnimationType.MoveLocalX:
                MoveLocalX();
                break;
            case AnimationType.MoveLocalY:
                MoveLocalY();
                break;
            case AnimationType.MoveLocal:
                MoveLocal();
                break;
            case AnimationType.RotateX:
                RotateX();
                break;
            case AnimationType.RotateY:
                RotateY();
                break;
            case AnimationType.RotateZ:
                RotateZ();
                break;
            case AnimationType.Rotate:
                Rotate();
                break;
            case AnimationType.RotateLocal:
                RotateLocal();
                break;
            case AnimationType.ScaleX:
                ScaleX();
                break;
            case AnimationType.ScaleY:
                ScaleY();
                break;
            case AnimationType.ScaleZ:
                ScaleZ();
                break;
            case AnimationType.Scale:
                Scale();
                break;
            case AnimationType.Alpha:
                Fade();
                break;
            case AnimationType.Color:
                Color();
                break;
        }

        _tweenObject.setDelay(_delay);
        _tweenObject.setEase(_easeType);
        _tweenObject.setIgnoreTimeScale(_useUnscaledTime);

        if(_loop)
        {
            _tweenObject.setLoopCount(int.MaxValue);
        }
        if(_pingPong)
        {
            _tweenObject.setLoopPingPong();
        }
    }

    private void SwapValues()
    {
        if(_animationType == AnimationType.Color)
        {
            Color _temp = _colorFrom;
            _colorFrom = _colorTo;
            _colorTo = _temp; 
        }
        else if(_animationType == AnimationType.Move
            || _animationType == AnimationType.MoveLocal
            || _animationType == AnimationType.Rotate
            || _animationType == AnimationType.RotateLocal
            || _animationType == AnimationType.Scale)
        {
            Vector3 _temp = _vectorFrom;
            _vectorFrom = _vectorTo;
            _vectorTo = _temp;
        }
        else
        {
            float _temp = _floatFrom;
            _floatFrom = _floatTo;
            _floatTo = _temp;
        }
    }

    public void Disable()
    {
        SwapValues();

        HandleTween();

        _tweenObject.setOnComplete(() =>
        {
            SwapValues();
            _objectToDisable.SetActive(false);
        });
    }

    #region Animating
    private void MoveX()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.anchoredPosition = new Vector2(_floatFrom, _objRectTransform.anchoredPosition.y);
        }

        _tweenObject = LeanTween.moveX(_objRectTransform, _floatTo, _duration);
    }

    private void MoveY()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.anchoredPosition = new Vector2(_objRectTransform.anchoredPosition.x, _floatFrom);
        }
        
        _tweenObject = LeanTween.moveY(_objRectTransform, _floatTo, _duration);
    }

    private void Move()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.anchoredPosition = new Vector2(_vectorFrom.x, _vectorFrom.y);
        }

        _tweenObject = LeanTween.move(_objRectTransform, _vectorTo, _duration);
    }

    private void MoveLocalX()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localPosition = new Vector3(_floatFrom, _objRectTransform.localPosition.y, _objRectTransform.localPosition.z);
        }
        
        _tweenObject = LeanTween.moveLocalX(_objectToAnimate, _floatTo, _duration);
    }

    private void MoveLocalY()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localPosition = new Vector3(_objRectTransform.localPosition.x, _floatFrom, _objRectTransform.localPosition.z);
        }
        
        _tweenObject = LeanTween.moveLocalY(_objectToAnimate, _floatTo, _duration);
    }

    private void MoveLocal()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localPosition = _vectorFrom;
        }

        _tweenObject = LeanTween.moveLocal(_objectToAnimate, _vectorTo, _duration);
    }

    private void RotateX()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.rotation = Quaternion.Euler(_floatFrom, _objRectTransform.rotation.y, _objRectTransform.rotation.z);
        }

        _tweenObject = LeanTween.rotateX(_objectToAnimate, _floatTo, _duration);
    }

    private void RotateY()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.rotation = Quaternion.Euler(_objRectTransform.rotation.x, _floatFrom, _objRectTransform.rotation.z);
        }

        _tweenObject = LeanTween.rotateY(_objectToAnimate, _floatTo, _duration);
    }

    private void RotateZ()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.rotation = Quaternion.Euler(_objRectTransform.rotation.x, _objRectTransform.rotation.y, _floatFrom);
        }

        _tweenObject = LeanTween.rotateZ(_objectToAnimate, _floatTo, _duration);
    }

    private void Rotate()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.rotation = Quaternion.Euler(_vectorFrom);
        }

        _tweenObject = LeanTween.rotate(_objectToAnimate, _vectorTo, _duration);
    }

    private void RotateLocal()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localRotation = Quaternion.Euler(_vectorFrom);
        }

        _tweenObject = LeanTween.rotateLocal(_objectToAnimate, _vectorTo, _duration);
    }

    private void ScaleX()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localScale = new Vector3(_floatFrom, _objRectTransform.localScale.y, _objRectTransform.localScale.z);
        }

        _tweenObject = LeanTween.scaleX(_objectToAnimate, _floatTo, _duration);
    }

    private void ScaleY()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localScale = new Vector3(_objRectTransform.localScale.x, _floatFrom, _objRectTransform.localScale.z);
        }

        _tweenObject = LeanTween.scaleY(_objectToAnimate, _floatTo, _duration);
    }

    private void ScaleZ()
    {
        RectTransform _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localScale = new Vector3(_objRectTransform.localScale.x, _objRectTransform.localScale.y, _floatFrom);
        }

        _tweenObject = LeanTween.scaleZ(_objectToAnimate, _floatTo, _duration);
    }


    private void Scale()
    {
        _objRectTransform = _objectToAnimate.GetComponent<RectTransform>();
        if(_startPositionOffset)
        {
            _objRectTransform.localScale = _vectorFrom;
        }

        _tweenObject = LeanTween.scale(_objectToAnimate, _vectorTo, _duration);
    }

    private void Fade()
    {
        if(_objectToAnimate.GetComponent<CanvasGroup>() == null)
        {
            _objectToAnimate.AddComponent<CanvasGroup>();
        }

        _objCanvasGroup = _objectToAnimate.GetComponent<CanvasGroup>();
        if(_startPositionOffset)
        {
            _objCanvasGroup.alpha = _floatFrom;
        }

        _tweenObject = LeanTween.alphaCanvas(_objCanvasGroup, _floatTo, _duration);
    }

    private void Color()
    {
        _objColor = _objectToAnimate.GetComponent<Material>().color;
        if(_startPositionOffset)
        {
            _objColor = _colorFrom;
        }

        _tweenObject = LeanTween.color(_objectToAnimate, _colorTo, _duration);
    }
    #endregion
}