using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float[] xlimit;
    [SerializeField]
    private float[] xPosition;
    [SerializeField]
    private GameObject[] enemy;
    [SerializeField]
    private Wave[] wave;

    private float currentTime;
    List<float> remainingPosition = new List<float>();
    private int waveIndex;
    float xPos = 0;
    int rand;
    void Start()
    {
        currentTime = 0;
        remainingPosition.AddRange(xPosition);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0){
            SelectWave();
        }
    }

    void SpawnEnemy(float xPos){
        int r = Random.Range(0, 2);
        GameObject enemyObj = Instantiate(enemy[r], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }

    void SelectWave(){
        remainingPosition = new List<float>();
        remainingPosition.AddRange(xPosition);
        waveIndex = Random.Range(0, wave.Length);
        currentTime = wave[waveIndex].delayTime;
        if(wave[waveIndex].spawnAmount == 1){
            xPos = Random.Range(0, xlimit[1]);
        }
        else{
            rand = Random.Range(0, remainingPosition.Count);
            xPos = remainingPosition[rand];
            remainingPosition.RemoveAt(rand);
        }
        for(int i=0;i< wave[waveIndex].spawnAmount;i++){
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPosition.Count);
            xPos = remainingPosition[rand];
            remainingPosition.RemoveAt(rand);

        }
    }

}
[System.Serializable]
public class Wave{
    public float delayTime;
    public float spawnAmount;
}
