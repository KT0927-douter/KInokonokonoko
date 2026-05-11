using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int money = 0;
    public int harvestCount = 0;
    public GameObject rareMushroomPrefab;

    public TextMeshProUGUI moneyText;
    public GameObject baseMushroom;
    public GameObject mushroom;
    public float timer=0;

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
        moneyText.text = "Money : $" + money;

        if (harvestCount >= 10)
        {
            harvestCount = 0;

            SpawnRareMushroom();
        }
    }
    // Update is called once per frame
    void Update()
    {
     if(mushroom==null)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
             Instantiate(baseMushroom,Vector3.zero,Quaternion.identity);
                timer = 0f;
            }
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
