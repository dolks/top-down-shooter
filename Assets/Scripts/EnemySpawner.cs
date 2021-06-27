using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        StartCoroutine(spawnAllWaves());
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator spawnAllWaves()
    {
        foreach(WaveConfig wave in waves)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(wave));
        }
    }

}
