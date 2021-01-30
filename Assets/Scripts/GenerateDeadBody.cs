using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDeadBody : MonoBehaviour
{
    [SerializeField]
    GameObject DeadBodyPrefab;

    public void LeaveDeadBody() {
        GameObject go = GameObject.Instantiate(DeadBodyPrefab,transform.position,Quaternion.identity);
        DontDestroyOnLoad(go);
    }
}
