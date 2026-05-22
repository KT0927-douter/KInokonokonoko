using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // キノコ系変数
    public float respawnTimer = 0f;
    public int money = 0;
    public int kinoko;
    public int Kendama;
    public int Cymbal;
    public int UFO;
    public bool gameEnd = false;
    public int harvestCount = 0;
    public GameObject rareMushroomPrefab;

    // ゲーム時間
    public float timer = 60f;
    public TMP_Text timerText;

    public TextMeshProUGUI moneyText;
    public GameObject baseMushroom;
    public GameObject mushroom;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateMoneyUI();
    }



    public void AddMoney(int amount)
    {
        money += amount;
        harvestCount++;

        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        moneyText.text = "Pepole/kinoko: $" + money;

        if (harvestCount >= 10)
        {
            harvestCount = 0;

            SpawnRareMushroom();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // 中央のキノコが消えてたら・・・５秒後に復活させる
        if (mushroom == null)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > 5f)
            {
                mushroom = Instantiate(baseMushroom, Vector3.zero, Quaternion.identity);
                respawnTimer = 0f;
            }
        }

        // ゲーム時間タイマー　60からのカウントダウン
        timer -= Time.deltaTime;

        timerText.text = "Time : " + Mathf.Ceil(timer).ToString();

        // タイマーが０になったら...（未実装）
        if (timer <= 0)
        {
            timer = 0;
            //PlayerPrefs.SetInt("Score", money);
            //PlayerPrefs.SetInt("kinokoCount", kinoko);

            //PlayerPrefs.SetInt("KendamaCount", Kendama);

            //PlayerPrefs.SetInt("CymbalCount", Cymbal);

            //PlayerPrefs.SetInt("UFOCount", UFO);

            //PlayerPrefs.Save();

            SceneManager.LoadScene("EndScene");
        }

    }

    void SpawnRareMushroom()
    {
        Vector2 pos = new Vector2(
            Random.Range(-6f, 6f),
            Random.Range(-3f, 3f)
        );

        Instantiate(rareMushroomPrefab, pos, Quaternion.identity);

        Debug.Log("レアキノコ出現！");
    }
}
