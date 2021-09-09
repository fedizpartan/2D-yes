using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] int numEnemies;
    [SerializeField] GameObject GameOverMenu;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu
            }
        }
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

  
    public void KillAnimals()
    {
        numEnemies--;
        if(numEnemies < 1)
        {
            //ganar
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }
}
