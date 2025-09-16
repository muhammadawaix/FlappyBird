using System.Collections;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject obstacles;
    [SerializeField] private GameObject coin;
    private float coinSpawnChance = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ObstaclsStart());
    }


    IEnumerator ObstaclsStart()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
                Vector3 spawnPos = new Vector3(5.0f, Random.Range(-1.5f, 2.5f), 0.0f);
                Instantiate(obstacles, spawnPos, Quaternion.identity);


                if (Random.value < coinSpawnChance)
                {
                    Vector3 coinPos = new Vector3(spawnPos.x, spawnPos.y, 0.0f);
                    Instantiate(coin, coinPos, Quaternion.identity);
                }

                yield return new WaitForSeconds(2.0f);
        }
    }
}
