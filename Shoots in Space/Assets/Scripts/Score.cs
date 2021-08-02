using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score:" + score;
    }
}
