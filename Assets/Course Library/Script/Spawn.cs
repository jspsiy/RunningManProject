using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] obstacles;
    double timeRef;
    private PlayerController pcScript;
    // Start is called before the first frame update
    void Start()
    {
        timeRef = 0;
        pcScript = GameObject.Find("Player").GetComponent < PlayerController > ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeAsDouble > timeRef)
        {
            if (pcScript.gameOver == false)
            {
                int index = Random.Range(0, obstacles.Length);
                Vector3 spawnPos = GameObject.Find("Player").transform.position;
                spawnPos.x += spawnPos.x + Random.Range(20, 30);
                spawnPos.y = 5;
                Instantiate(obstacles[index], spawnPos, obstacles[index].transform.rotation);
            }
            timeRef = Time.timeAsDouble + 5;
        }
    }
}
