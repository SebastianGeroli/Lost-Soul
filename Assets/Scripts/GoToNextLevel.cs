using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public  class GoToNextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NextLevelTag>())
        {
            ScenePosition.UseSecondPosition = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.GetComponent<PreviousLevelTag>()) {
            if (SceneManager.GetActiveScene().buildIndex == 0) {
                Application.Quit();
            }
            ScenePosition.UseSecondPosition = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
