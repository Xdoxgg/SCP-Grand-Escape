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
    [SerializeField] private DoorTrigger _trigger;

    void Start()
    {
        _navMeshAgent.autoBraking = false;
        _navMeshAgent.isStopped = true;
    }

    void Update()
    {
        if (_navMeshAgent.isActiveAndEnabled && _trigger.Ready)
        {
            Vector3 viewportPoint = _playerCamera.WorldToViewportPoint(_scp173.transform.position);

    
            bool find = false;
            float raycastDistance = 15f;
            float raycastWidth = 6f;
            for (float x = -raycastWidth / 2; x <= raycastWidth / 2; x += 0.5f)
            {
                Vector3 rayOrigin = _playerCamera.transform.position;
                Vector3 rayDirection = _playerCamera.transform.forward;
                rayOrigin += _playerCamera.transform.right * x;

                if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, raycastDistance))
                {
                    GameObject hitObject = hit.collider.gameObject;

                    if (hitObject == _scp173)
                    {
                        find = true;
                        break;
                    }
                }
            }

            if (find)
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.velocity = Vector3.zero;
            }
            else
            {
                _navMeshAgent.isStopped = false;
            }
        }
    }
}