using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    // ScoreText を入れる場所
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 保存していたスコアを取得
        int score = PlayerPrefs.GetInt("Score");

        // Textにスコア表示
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
