using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    // ScoreText を入れる場所
    public TMP_Text scoreText;
    public TMP_Text kinokoText;
    public TMP_Text KendamaText;
    public TMP_Text CymbalText;
    public TMP_Text UFOText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 保存していたスコアを取得
        int score = PlayerPrefs.GetInt("Score");

        // Textにスコア表示
        scoreText.text = "スコア : " + score;
        kinokoText.text = "キノコ : " + GameManager.instance.kinoko.ToString();

        KendamaText.text = "ケンダマ : " + GameManager.instance.Kendama.ToString();

        CymbalText.text = "シンバル : " + GameManager.instance.Cymbal.ToString();

        UFOText.text = "UFO : " + GameManager.instance.UFO.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
