using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GoToNextLevel : MonoBehaviour
{
    public static event Action<int> GoingNextLevel;
    public static event Action<int> GoingBackLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NextLevelTag>())
        {
            ScenePosition.UseSecondPosition = false;
         

            if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                //
                GoingNextLevel?.Invoke(-1);
                SceneManager.LoadScene(0);
                return;
            }
            GoingNextLevel?.Invoke(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.GetComponent<PreviousLevelTag>())
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.Quit();
                return;
            }
            ScenePosition.UseSecondPosition = true;
            GoingBackLevel?.Invoke(SceneManager.GetActiveScene().buildIndex - 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
