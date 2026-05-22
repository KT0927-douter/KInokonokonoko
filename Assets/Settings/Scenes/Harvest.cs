using UnityEngine;

public class Harvest : MonoBehaviour
{
    public int mushCount = 0;    // 収穫したキノコの合計数
    private bool flag = false;          // 収穫モード中かどうか。　true → 収穫中
    public float radius = 1.5f;
    private new Collider2D collider;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }
    void Update()
    {
        // 右クリック開始
        if (Input.GetMouseButtonDown(1))
        {
            flag = true;
        }
        // 右クリック終了
        else if (Input.GetMouseButtonUp(1))
        {
            flag= false;
        }
        // 収穫中
        if (flag)
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 10f; // カメラからの距離を指定
        // ワールド座標へ変換
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            transform.position = worldPos;
            // 範囲内のCollider全部取得
            Collider2D[] hits =
                Physics2D.OverlapCircleAll(
                    transform.position,
                    radius
                );

            // 範囲内で見つかったColliderを1個ずつ処理
            foreach (Collider2D collision in hits)
            {
                // タグが「kinokonoko」じゃなければ無視
                if (!collision.CompareTag("Player"))
                {
                    Debug.Log("タグがPlayerではない");
                    continue;
                }

                // Mushroomスクリプトを取得
                Mushroom mushroom =
                    collision.GetComponent<Mushroom>();

                // Mushroomが無い または 親キノコなら収穫しない
                if (mushroom == null || mushroom.isStarter)
                {
                    Debug.Log("Mushroomがない");
                    continue;
                }

                // キノコの価値分お金を追加
                GameManager.instance.AddMoney(mushroom.value);

                switch (mushroom.type)
                {
                    case Mushroom.MushroomType.kinoko:
                        GameManager.instance.kinoko++;
                        break;

                    case Mushroom.MushroomType.Kendama:
                        GameManager.instance.Kendama++;
                        break;

                    case Mushroom.MushroomType.Cymbal:
                        GameManager.instance.Cymbal++;
                        break;

                    case Mushroom.MushroomType.UFO:
                        GameManager.instance.UFO++;
                        break;
                }

                // 当たり判定をOFF
                //collision.enabled = false;

                // キノコオブジェクトを削除
                Destroy(collision.gameObject);

                // 収穫音を再生
                SoundManager.instance.PlaySE(0);

                // 収穫したキノコ数を増やす
                mushCount++;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (flag == false || !collision.CompareTag("kinokonoko"))
        {
            return;
        }

        Mushroom mushroom = collision.GetComponent<Mushroom>();

        if (mushroom == null || mushroom.isStarter)
        {
            return;
        }

        GameManager.instance.AddMoney(mushroom.value);

        collision.enabled = false;

        Destroy(collision.gameObject);

        SoundManager.instance.PlaySE(0);

        mushCount++;
    }

    // バグってるっぽいので修正版↑
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (flag == false || collision.CompareTag("kinokonoko"))
    //    {
    //        return;
    //    }
    //    Mushroom mushroom = collision.GetComponent<Mushroom>();
    //    // Mushroomが無いなら終了
    //    if (mushroom == null || mushroom.isStarter == false)
    //    {
    //        return;
    //    }

    //    if (mushroom.isStarter)
    //    {
    //        return;
    //    }

    //    GameManager.instance.AddMoney(mushroom.value);
    //    collision.enabled = false;
    //    Destroy(collision.gameObject);
    //    //scoreManager.instance.Addscore(10);
    //    SoundManager.instance.PlaySE(0);
    //    mushCount++;
    //}
}
