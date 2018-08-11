using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject quitMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenuUI.SetActive(false);
            enableMainMenu();
        }
    }
    void enableMainMenu()
    {
        mainMenuUI.SetActive(true);
    }
}
