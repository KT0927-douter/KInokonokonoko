using UnityEngine;

public class Spore : MonoBehaviour
{
    public float lifetime = 1;
    public GameObject mushroomPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(mushroomPrefab, transform.position, Quaternion.identity);
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
            Instantiate(mushroomPrefab,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
