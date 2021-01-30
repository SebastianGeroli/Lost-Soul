using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject masterPanel;

    [SerializeField]
    GameObject mainMenu;
    private void Awake()
    {
        if (masterPanel.activeInHierarchy)
        {
            masterPanel.SetActive(false);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetButtonDown("PauseMenu"))
        {
            ShowPause();
        }
    }

    void ShowPause()
    {
        if (mainMenu != null && mainMenu.activeInHierarchy)
        {
            return;
        }
        if (masterPanel.activeInHierarchy)
        {
            masterPanel.SetActive(false);
        }
        else
        {
            masterPanel.SetActive(true);
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
