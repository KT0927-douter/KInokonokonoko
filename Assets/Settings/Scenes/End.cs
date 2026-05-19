using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックでタイトルへ
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
