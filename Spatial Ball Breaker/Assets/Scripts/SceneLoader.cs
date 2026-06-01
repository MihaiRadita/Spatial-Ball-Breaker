using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Victory Scene")
        {
            Cursor.visible = true;
            SetGameOver(true);
        }
    }

    public void ResetScore()
    {
        GameStatus status = FindObjectOfType<GameStatus>();
        if(status != null)
        {
            if (SceneManager.GetActiveScene().buildIndex > 1 && SceneManager.GetActiveScene().name != "Victory Scene")
            {
                status.scoreObtained = status.previousLevelScore;
            }
            else
            {
                status.scoreObtained = 0;
            }
            status.scoreText.text = status.scoreObtained.ToString();
        }

    }
    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        GameStatus status = FindObjectOfType<GameStatus>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
        {
            status.previousLevelScore = status.scoreObtained;
        }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SetGameOver(bool value)
    {
        GameStatus status = FindObjectOfType<GameStatus>();
        if(status != null)
        {
            status.gameOver = value;
        }
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}