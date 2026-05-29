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
    public TMP_Text MokemoText;
    public TMP_Text IceText;
    public TMP_Text TitiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 保存していたスコアを取得
        //int score = PlayerPrefs.GetInt("Score");

        // Textにスコア表示
        scoreText.text = "スコア: " + GameManager.instance.money.ToString();
        kinokoText.text = ": " + GameManager.instance.kinoko.ToString();

        KendamaText.text = ": " + GameManager.instance.Kendama.ToString();

        CymbalText.text = ": " + GameManager.instance.Cymbal.ToString();

        UFOText.text = ": " + GameManager.instance.UFO.ToString();

        MokemoText.text = ": " + GameManager.instance.Mokemo.ToString();

        IceText.text = ": " + GameManager.instance.Ice.ToString();

        TitiText.text = ": " + GameManager.instance.Titi.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
