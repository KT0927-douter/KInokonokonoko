using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int money = 0;

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

        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        moneyText.text = "Money : $" + money;
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
}
