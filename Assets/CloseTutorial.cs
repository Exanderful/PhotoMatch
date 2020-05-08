using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    public GameObject tutorObj;

    // Update is called once per frame
    public void OnClick()
    {
        Object.Destroy(tutorObj);
    }
}
