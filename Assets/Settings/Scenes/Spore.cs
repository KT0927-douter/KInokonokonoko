using UnityEngine;

public class Spore : MonoBehaviour
{
    public float lifetime = 1;
    public GameObject mushroomPrefab;
    public GameObject mushroomPrefab2;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            float num = Random.Range(0f, 1f);
            if (num <= 0.95f)
            {
                Instantiate(mushroomPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(mushroomPrefab2, transform.position, Quaternion.identity);
            }
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
    lifetime-= Time.deltaTime;
        if (lifetime < 0)
        {
            float num = Random.Range(0f, 1f);
            if (num <= 0.95f)
            {
                Instantiate(mushroomPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(mushroomPrefab2, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
