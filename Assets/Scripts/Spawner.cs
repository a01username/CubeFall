using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawnTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        while (true) 
        {
            GameObject zombieCopy1 = Instantiate(zombie);
            zombieCopy1.transform.position = new Vector3(Random.Range(-27, 27f), 21f, Random.Range(-27, 27f));
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            GameObject zombieCopy2 = Instantiate(zombie);
            zombieCopy2.transform.position = new Vector3(Random.Range(-27, 27f), 21f, Random.Range(-27, 27f));
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            GameObject zombieCopy3 = Instantiate(zombie);
            zombieCopy3.transform.position = new Vector3(Random.Range(-27, 27f), 21f, Random.Range(-27, 27f));
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            GameObject zombieCopy4 = Instantiate(zombie);
            zombieCopy4.transform.position = new Vector3(Random.Range(-27, 27f), 21f, Random.Range(-27, 27f));
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            GameObject zombieCopy5 = Instantiate(zombie);
            zombieCopy5.transform.position = new Vector3(Random.Range(-27, 27f), 21f, Random.Range(-27, 27f));
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            GameObject zombieCopy6 = Instantiate(zombie);
            zombieCopy6.transform.position = new Vector3(Random.Range(-27, 27f), 21f, Random.Range(-27, 27f));
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
        }
    }
}
