using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadBody : MonoBehaviour
{
   int sceneID;
   public int SceneID { get=>sceneID ; set => sceneID = value; }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != sceneID) {
            Destroy(gameObject);
        }
    }
    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        if (arg0 != arg1) {
            SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
            Destroy(gameObject);
        }
    }
}
