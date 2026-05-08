using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public bool isStarter = false; // 最初のキノコかどうか
    public GameObject sporePrefab;
    public int value = 1;
    private int count = 0;
    public int maxTouchCount = 3;

    bool alreadyHarvested = false;

    // 連続収穫の間隔（小さいほど速い）
    float harvestInterval = 0.1f;
    float harvestTimer = 0f;

    void OnMouseDown()
    {
        //Debug.Log("マウス押された");
        count ++;
        for (int i = 0; i < 3; i++)
        {
            GameObject spore = Instantiate(sporePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = spore.GetComponent<Rigidbody2D>();

            // ★ 上だけじゃなくランダムに飛ばす
            Vector2 dir = new Vector2(
                Random.Range(-1f, 1f),
                Random.Range(-0.8f, 0.8f) // ←ここ重要（下にも飛ぶ）
            );
            if (dir.sqrMagnitude > 1.0f)
            {
                dir.Normalize();
            }
            rb.AddForce(dir * 3f, ForceMode2D.Impulse);
        }
        if (count >= maxTouchCount)
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右クリック長押し
        if (Input.GetMouseButton(1))
        {
            harvestTimer += Time.deltaTime;

            if (harvestTimer >= harvestInterval)
            {
                harvestTimer = 0f;

                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D col = Physics2D.OverlapPoint(pos);

                if (col != null)
                {
                    Mushroom m = col.GetComponent<Mushroom>();

                    if (m != null)
                    {
                        m.Harvest();
                    }
                }
            }
        }
        else
        {
            harvestTimer = 0f;
        }
    }
    public void Harvest()
    {
        //if (isStarter) return;
        if (alreadyHarvested) return;

        alreadyHarvested = true;

        GameManager.instance.AddMoney(value);

        Destroy(gameObject);
    }
}
