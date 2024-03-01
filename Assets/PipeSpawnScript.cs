using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public Text scoreText;
    public int rorationThreshold = 25;
    public int maximumRotation = 32;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        } else
        {
            SpawnPipe();
            timer = 0;
        } 
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        int playerScore = int.Parse(scoreText.text);

        if (playerScore > rorationThreshold) // If the player score is higher than the rotation threshold, then the pipes can rotate
        {
            int pipeType = Mathf.RoundToInt(Random.Range(0.0f, 1.0f)); // When 0, the pipe doesn't rotate; when 1, it rotates.
            if (pipeType == 0)
            {
                Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            } else
            {
                float randomRotation = Random.Range(-maximumRotation, maximumRotation);
                Quaternion rotation = Quaternion.Euler(0, 0, randomRotation);
                Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint + 5, highestPoint - 5), 0), rotation);
            }
            
        } else
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }
}
