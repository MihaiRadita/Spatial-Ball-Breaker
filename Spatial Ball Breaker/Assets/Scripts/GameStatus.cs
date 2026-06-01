using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instance = null;
    public int scoreObtained = 0;
    public int previousLevelScore = 0;
    public TextMeshProUGUI scoreText;
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    public bool gameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        scoreText.text = scoreObtained.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}