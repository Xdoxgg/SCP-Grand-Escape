using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP049 : MonoBehaviour
{
    [SerializeField] private DoorTrigger _trigger;
    [SerializeField] private NavMeshAgent _agent;
    
    void Update()
    {
        if (!_trigger.Ready)
        {
            _agent.isStopped = true;
        }
        else
        {
            _agent.isStopped = false;
        }
    }
}