using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float pipeSpeed = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * pipeSpeed;
        //if pipe x position is less than -7, destroy pipe
        if (transform.position.x < -7f)
        {
            Destroy(gameObject);
        }

    }


}
