using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject quitMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenu.SetActive(true);
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void QuitMenuYes()
    {
        Application.Quit();
    }
    public void QuitMenuNo()
    {
        quitMenu.SetActive(false);
    }
}
