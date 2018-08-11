using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public static bool quitMenuEnabled = false;
    public GameObject mainMenuUI;
    public GameObject quitMenuUI;

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
           if(quitMenuEnabled)
            {
                disableQuitMenu();
                mainMenuUI.SetActive(true);
            }
           else
            {
                mainMenuUI.SetActive(false);
                enableQuitMenu();
            }
        }
    }
    void disableQuitMenu()
    {
        quitMenuUI.SetActive(false);
        quitMenuEnabled = false;
    }
    void enableQuitMenu()
    {
        quitMenuUI.SetActive(true);
        quitMenuEnabled = true;
    }
}
