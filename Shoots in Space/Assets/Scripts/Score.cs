using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score:" + score;
        if(score >= 60 && score <= 120){
            GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>().initialWaveEnemyCount = 1;
            GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>().initialWaveEnemyCount = 3;
        }else if(score > 120 && score <= 160){
            GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>().initialWaveEnemyCount = 2;
            GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>().initialWaveEnemyCount = 4;
        }else if(score > 160 && score <= 220){
            GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>().initialWaveEnemyCount = 3;
            GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>().initialWaveEnemyCount = 5;
        }else if(score > 220 && score <= 320){
            GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>().initialWaveEnemyCount = 4;
            GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>().initialWaveEnemyCount = 6;
        }else if(score > 320){
            GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>().initialWaveEnemyCount = 5;
            GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>().initialWaveEnemyCount = 6;
        }
    }
}
