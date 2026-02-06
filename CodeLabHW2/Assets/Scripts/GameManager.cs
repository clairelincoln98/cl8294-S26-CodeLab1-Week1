using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float time;
    
    public int targetTime = 10;
    
    public int currentLevel = 0;

    public static GameManager instance;
    
    public TMP_Text scoreText;

    string defaultScoreText = "Survive: <targetTime> TimePassed: <time>";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string updatedScoreText = defaultScoreText;

        updatedScoreText = updatedScoreText.Replace("<time>", time + "");
        updatedScoreText = updatedScoreText.Replace("<targetTime>", targetTime + "");
        
        scoreText.text = updatedScoreText;

        if (time >= targetTime)
        {
            time = 0;
            currentLevel++;
            targetTime = targetTime * 2;
            SceneManager.LoadScene(currentLevel);
        }

    }
}
