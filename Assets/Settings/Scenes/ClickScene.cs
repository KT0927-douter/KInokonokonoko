using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickScene : MonoBehaviour
{
    // 次に行くシーン名
    public string nextSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // マウス左クリックしたら
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

