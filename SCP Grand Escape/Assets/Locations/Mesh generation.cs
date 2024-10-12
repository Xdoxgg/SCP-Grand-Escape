using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshgeneration : MonoBehaviour
{
    [SerializeField]
    private Mesh _mesh;
    public Vector3[] vertecs;
    public int[] tiagle;


    void Start()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _mesh.vertices=vertecs;
        _mesh.triangles=tiagle;
    }


    void Update()
    {
        
    }
}
