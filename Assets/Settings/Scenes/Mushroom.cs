using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public bool isStarter = false; // 最初のキノコかどうか
    public GameObject sporePrefab;

    void OnMouseDown()
    {
        //Debug.Log("マウス押された");
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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右クリック → 採取
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.OverlapPoint(pos);

            if (col != null && col.gameObject == gameObject)
            {
                Harvest();
            }
        }

        void Harvest()
        {
            if (!isStarter) // ← 最初じゃないなら消す
            {
                Destroy(gameObject);
            }
        }
    }
}
