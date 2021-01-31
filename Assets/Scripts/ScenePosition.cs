using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePosition : MonoBehaviour
{
    public static bool UseSecondPosition = false;
    public Transform secondPosition;
    private void Start()
    {
        if (UseSecondPosition) {
            transform.position = secondPosition.position;
        }
    }
}
