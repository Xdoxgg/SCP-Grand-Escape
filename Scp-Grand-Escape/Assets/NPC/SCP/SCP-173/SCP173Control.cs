using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Timers;

public class SCP173Control : MonoBehaviour
{
    [SerializeField] private GameObject _scp173;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshAgent _navMeshAgent;


    void Start()
    {
        _navMeshAgent.autoBraking = false;
    }
    
    void Update()
    {
     
        
        if (_navMeshAgent.isActiveAndEnabled)
        {
            Vector3 viewportPoint = _playerCamera.WorldToViewportPoint(_scp173.transform.position);

            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
                viewportPoint.z > 0)
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.velocity=Vector3.zero;
                
            }
            else
            {
                _navMeshAgent.isStopped = false;
            }

        }
    }
}