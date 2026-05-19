using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックしたらゲーム開始
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
