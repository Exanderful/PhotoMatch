using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GEM.Game.Scenes;
using GEM.Game.Common;

public class PhotoClick : MonoBehaviour
{
    public float InteractionTime = 1f;

    public CandyColor color;

    public IEnumerator TouchHold()
    {
        Debug.Log("Touched");
        float _time = 0;

#if UNITY_EDITOR
        while (Input.GetMouseButton(0) && _time < InteractionTime)
        {
            _time += Time.deltaTime;
            yield return null;
        }
        if (Input.GetMouseButton(0))
        {
            if (color == CandyColor.Blue)
            {
                GameScene.instance.OpenImagePreview(1);
            }
            if (color == CandyColor.Green)
            {
                GameScene.instance.OpenImagePreview(2);
            }
            if (color == CandyColor.Orange)
            {
                GameScene.instance.OpenImagePreview(3);
            }
            if (color == CandyColor.Purple)
            {
                GameScene.instance.OpenImagePreview(4);
            }
            if (color == CandyColor.Red)
            {
                GameScene.instance.OpenImagePreview(5);
            }
            if (color == CandyColor.Yellow)
            {
                GameScene.instance.OpenImagePreview(6);
            }
            GameScene.ButtonHoldDelegateHandler?.Invoke();
        }
#endif
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            while (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary && _time < InteractionTime)
            {
                _time += Time.deltaTime;
                yield return null;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                if (color == CandyColor.Blue)
                {
                    GameScene.instance.OpenImagePreview(1);
                }
                if (color == CandyColor.Green)
                {
                    GameScene.instance.OpenImagePreview(2);
                }
                if (color == CandyColor.Orange)
                {
                    GameScene.instance.OpenImagePreview(3);
                }
                if (color == CandyColor.Purple)
                {
                    GameScene.instance.OpenImagePreview(4);
                }
                if (color == CandyColor.Red)
                {
                    GameScene.instance.OpenImagePreview(5);
                }
                if (color == CandyColor.Yellow)
                {
                    GameScene.instance.OpenImagePreview(6);
                }
                GameScene.ButtonHoldDelegateHandler?.Invoke();
            }
        }
#endif
    }

    public void OnMouseDown()
    {
        StartCoroutine(TouchHold());
    }
}
