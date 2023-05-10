using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < startPos.x - GetComponent<BoxCollider>().size.x/2)
        {
            gameObject.transform.position = startPos;
            
        }
    }
}
