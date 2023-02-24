using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 10; i <= 50; i += 10)
        {
            var rndNbr = Random.Range(1, 6);

            int yPos;
            
            if (i == 10)
            {
                yPos = 10;
            }
            else
            {
                yPos = Random.Range(i - 7, i - 2);
            }
            
            if (rndNbr <= 3)
            {
                Instantiate(_asteroidPrefab, new Vector3(5f, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f, yPos, 0f), Quaternion.identity);
            }
            else if (rndNbr == 4)
            {
                Instantiate(_asteroidPrefab, new Vector3(5f + 1, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f + 1, yPos, 0f), Quaternion.identity);
            }
            else if (rndNbr == 5)
            {
                Instantiate(_asteroidPrefab, new Vector3(5f - 1, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f - 1, yPos, 0f), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // _time += Time.deltaTime;
        //
        // if (_time >= _spawnTime)
        // {
        //     _time = 0f;
        //
        //     var xPos = Random.Range(-1, 2);
        //     
        //     Vector3 spawnPos = new Vector3(transform.position.x + xPos,
        //         transform.position.y, transform.position.z);
        //     
        //     Debug.Log(spawnPos);
        //
        //     GameObject Asteroid = Instantiate(_asteroidPrefab, spawnPos, Quaternion.identity);
        // }
    }

    // private IEnumerator DestroyCo(GameObject asteroid)
    // {
    //     yield return new WaitForSeconds(1f);
    //     Destroy(asteroid);
    // }
}
