using UnityEngine;

public class Harvest : MonoBehaviour
{
    private bool flag = false;
    private new Collider2D collider;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            flag = true;
            collider.enabled = true;
        } 
        else if(Input.GetMouseButtonUp(1))
        {
            flag= false;
            collider.enabled = false;
        }
        if(flag)
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 10f; // カメラからの距離を指定
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            transform.position = worldPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag == false||collision.CompareTag("kinokonoko"))
        {
            return;
        }
        Mushroom mushroom = collision.GetComponent<Mushroom>();
        Destroy(collision.gameObject);
        //scoreManager.instance.Addscore(10);
        GameManager.instance.AddMoney(mushroom.value);
    }
}
