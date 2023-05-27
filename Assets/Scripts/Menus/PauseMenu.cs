using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        isPaused= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused)
            {
                UnPauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        isPaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
        isPaused = false;
    }

    public void BackToMainMenu()
    {
        panel.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
