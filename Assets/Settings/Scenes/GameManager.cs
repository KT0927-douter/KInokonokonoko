using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreUI();
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
