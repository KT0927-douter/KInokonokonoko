using UnityEngine;
using TMPro;

public class MoneyPopup : MonoBehaviour
{
    // TextMeshProを入れる場所
    public TMP_Text text;

    // 消えるまでの時間
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 上へ動く
        transform.position += Vector3.up * 5f * Time.deltaTime;

        // 時間を進める
        timer += Time.deltaTime;

        // 1秒経ったら消える
        if (timer > 1f)
        {
            Destroy(gameObject);
        }
    }

    // 金額を表示する関数
    public void Setup(int money)
    {

        Debug.Log("Setup呼ばれた");

        text.text = "+" + money.ToString();
    }
}
