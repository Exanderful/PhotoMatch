using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGameModes : MonoBehaviour
{
    public GameObject[] gameModesButtons;

    bool clicked = false;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (!clicked)
        {
            StartCoroutine(onPlayAnimation());
            clicked = true;
        }
    }

    IEnumerator onPlayAnimation()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.5f).setEaseInOutBack();
        yield return new WaitForSeconds(0.5f);
        LeanTween.scale(gameModesButtons[0], new Vector3(1f, 1f, 1f), 0.4f).setEaseOutBack();
        LeanTween.scale(gameModesButtons[1], new Vector3(1f, 1f, 1f), 0.4f).setEaseOutBack();
        LeanTween.scale(gameModesButtons[2], new Vector3(1f, 1f, 1f), 0.4f).setEaseOutBack();
        //LeanTween.scale(gameModesButtons[3], new Vector3(1f, 1f, 1f), 0.4f).setEaseOutBack();
        yield return new WaitForSeconds(0.1f);
        LeanTween.moveLocalY(gameModesButtons[0], 200f, 0.4f).setEaseOutBack();
        LeanTween.moveLocalX(gameModesButtons[1], -200f, 0.4f).setEaseOutBack();
        LeanTween.moveLocalY(gameModesButtons[1], -100f, 0.4f).setEaseOutBack();
        LeanTween.moveLocalX(gameModesButtons[2], 200f, 0.4f).setEaseOutBack();
        LeanTween.moveLocalY(gameModesButtons[2], -100f, 0.4f).setEaseOutBack();
        //LeanTween.moveLocalY(gameModesButtons[3], -400f, 0.4f).setEaseOutBack();
    }
}