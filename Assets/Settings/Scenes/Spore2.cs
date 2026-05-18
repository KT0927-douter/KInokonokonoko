using UnityEngine;

public class Spore2 : MonoBehaviour
{
    public float lifetime = 1;
    public GameObject[] mushrooms = new GameObject[3];
    public float[] rates = new float[3];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Spawn()
    {
        float num = Random.Range(0f, 1f);
        for (int i = 0; i < rates.Length; i++)
        {
            num -= rates[i];
            if (num <= 0f)
            {
                Instantiate(mushrooms[i], transform.position, Quaternion.identity);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Spawn();
            Destroy(gameObject);
        }

        {
            // 画面外に行ったら削除
            if (transform.position.x > 10f ||
                transform.position.x < -10f ||
                transform.position.y > 6f ||
                transform.position.y < -6f)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Spawn();
            Destroy(gameObject);
        }
    }
}
