using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GenerateDeadBody : MonoBehaviour
{
    [SerializeField]
    GameObject DeadBodyPrefab;

    public void LeaveDeadBody() {
        GameObject go = GameObject.Instantiate(DeadBodyPrefab,transform.position,Quaternion.identity);
        go.tag = "Clear";
        go.AddComponent<DeadBody>().SceneID = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(go);
    }
}
