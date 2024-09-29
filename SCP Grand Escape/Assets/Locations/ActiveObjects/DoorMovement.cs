using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{

    [SerializeField]
    private  GameObject _door;

    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.y > 5f)
        {
            transform.position = GoDown(transform.position);
        }
        
    }
    private Vector3 GoDown(Vector3 position)
    {
        Vector3 vector = position;
        vector.y -= 0.3f * Time.deltaTime;
        return vector;
    }
}
