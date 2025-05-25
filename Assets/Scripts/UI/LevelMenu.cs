using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Класс для запуска меню уровня
public class LevelMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject nextLevelMenu;
    
    public void ActivateGameOver()
    {
        Cursor.visible = true;
        gameOverMenu.SetActive(true);
    }
    
    public void ActivateLevelMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        nextLevelMenu.SetActive(true);
    }
    
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
        
    public void QuitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
