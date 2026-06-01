using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over", LoadSceneMode.Additive);
        FindObjectOfType<SceneLoader>().SetGameOver(true);
        Cursor.visible = true;
    }
}
