using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject masterPanel;
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

    public void ShowPause()
    {
        if (masterPanel.activeInHierarchy)
        {
            masterPanel.SetActive(false);
        }
        else
        {
            masterPanel.SetActive(true);
        }
    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
