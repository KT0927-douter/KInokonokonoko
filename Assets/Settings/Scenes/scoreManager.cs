using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    [Serialize]private int score;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    instance=this;    
    }

    // Update is called once per frame
    public void Addscore(int S)   
    {
        score += S;
        text.text = score.ToString();
    }
}
