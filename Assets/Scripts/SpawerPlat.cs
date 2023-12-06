using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawerPlat : MonoBehaviour
{
    public GameObject enemy;
    public bool spawnToForward = true;
    public float initialVelocity = 5;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            float randomXOffset = Random.Range(-transform.localScale.x * 0.5f, transform.localScale.x * 0.5f);
            float randomXOffset2 = Random.Range(-transform.localScale.x * 0.5f, transform.localScale.x * 0.5f);
            float spawnX = transform.position.x + randomXOffset;
            float spawnX2 = transform.position.x + randomXOffset2;
            float spawnZ = transform.position.z + (spawnToForward ? 1 : -1) * Random.Range(2f, 5f);
            GameObject enemyCopy1 = Instantiate(enemy, new Vector3(spawnX, transform.position.y, spawnZ), Quaternion.identity);
            GameObject enemyCopy2 = Instantiate(enemy, new Vector3(spawnX2, transform.position.y, spawnZ), Quaternion.identity);
            Vector3 spawnDirection = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0F) * Vector3.forward;
            enemyCopy1.GetComponent<Rigidbody>().velocity = (spawnToForward ? 1 : -1) * spawnDirection * initialVelocity;
            enemyCopy2.GetComponent<Rigidbody>().velocity = (spawnToForward ? 1 : -1) * spawnDirection * initialVelocity;
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }
}