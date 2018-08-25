using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject quitMenuUI;

    public void QuickPlay()
    {
        SceneManager.LoadScene("Singleplayer");
    }

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                mainMenuUI.SetActive(false);
                enableQuitMenu();
        }
    }
    void enableQuitMenu()
    {
        quitMenuUI.SetActive(true);
    }
}
