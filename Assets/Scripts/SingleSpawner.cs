using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;

    private float _time;
    [SerializeField] private float _spawnTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        var xPos = Random.Range(-1, 2);
            
        Vector3 spawnPos = new Vector3(transform.position.x + xPos,
            transform.position.y, transform.position.z);
        
        Instantiate(_asteroidPrefab, spawnPos, Quaternion.identity);
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

    private IEnumerator DestroyCo(GameObject asteroid)
    {
        yield return new WaitForSeconds(1f);
        Destroy(asteroid);
    }
}
