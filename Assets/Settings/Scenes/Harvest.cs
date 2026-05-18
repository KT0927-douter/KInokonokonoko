using UnityEngine;

public class Harvest : MonoBehaviour
{
    public static int mushCount = 0;
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
        // Mushroomが無いなら終了
        if (mushroom == null)
        {
            return;
        }

        GameManager.instance.AddMoney(mushroom.value);
        Destroy(collision.gameObject);
        //scoreManager.instance.Addscore(10);
        SoundManager.instance.PlaySE(0);
        mushCount++;
    }
}
