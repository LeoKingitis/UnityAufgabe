
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    
    

    
    
    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver()      //activate the game over screen
    {
        gameOverScreen.SetActive(true);
        pauseScreen.SetActive(false);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)  //if the game is already pause, unpause it
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
            
        }
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);  //if the status is true the game will be paused and if it is false the game will unpause

        if (status)     //when the pause status is true change the timescale to 0 so the time stops, if time status is false change timescale to 1 
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
    
}
