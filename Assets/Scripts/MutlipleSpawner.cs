using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutlipleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 60; i <= 300; i += 10)
        {
            // generate a number between 1 and 5.
            var rndNbr = Random.Range(1, 6);

            // if rndNbr is 1, generate an asteroid to the left and and another in the center or the
            // right in a random way.
            if (rndNbr <= 2)
            {
                var yPos = Random.Range(i - 7, i + -2);
                
                Instantiate(_asteroidPrefab, new Vector3(5f -1f, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f -1f, yPos, 0f), Quaternion.identity);

                var xPos = Random.Range(0, 2);
                
                Instantiate(_asteroidPrefab, new Vector3(5f + xPos, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f + xPos, yPos, 0f), Quaternion.identity);
            }
            else if (rndNbr <= 4)
            {
                var yPos = Random.Range(i - 7, i - 2);
                Instantiate(_asteroidPrefab, new Vector3(5f +1f, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f +1f, yPos, 0f), Quaternion.identity);

                var xPos = Random.Range(-1, 1);
                
                Instantiate(_asteroidPrefab, new Vector3(5f + xPos, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f + xPos, yPos, 0f), Quaternion.identity);
            }
            else if (rndNbr == 5)
            {
                var yPos = Random.Range(i - 7, i - 2);
                
                Instantiate(_asteroidPrefab, new Vector3(5f, yPos, 0f), Quaternion.identity);
                Instantiate(_asteroidPrefab, new Vector3(-5f, yPos, 0f), Quaternion.identity);

                var xPos = Random.Range(1, 3);

                if (xPos == 1)
                {
                    Instantiate(_asteroidPrefab, new Vector3(5f + +1, yPos, 0f), Quaternion.identity);
                    Instantiate(_asteroidPrefab, new Vector3(-5f + +1, yPos, 0f), Quaternion.identity);
                }
                else if (xPos == 2)
                {
                    Instantiate(_asteroidPrefab, new Vector3(5f -1, yPos, 0f), Quaternion.identity);
                    Instantiate(_asteroidPrefab, new Vector3(-5f -1, yPos, 0f), Quaternion.identity);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
