using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    private bool paused = false;
    [SerializeField] GameObject pausepanel;
    private void Awake()
    {
        pausepanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void Resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
