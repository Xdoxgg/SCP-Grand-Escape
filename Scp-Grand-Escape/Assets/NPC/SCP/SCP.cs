using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SCP : MonoBehaviour
{
    [SerializeField] protected Transform[] _points;
    [SerializeField] protected Transform _currentPoint;
    [SerializeField] protected GameObject _scp;
    [SerializeField] protected GameObject _player;
    [SerializeField] protected NavMeshAgent _navMeshAgent;
    [SerializeField] protected string _name;

    private enum Mode
    {
        potrul,
        player
    }

    private Mode _mode = Mode.potrul;

    void Start()
    {
        GoToPoint();
    }

    private void Update()
    {
        if ((transform.position - _currentPoint.position).magnitude < 5f)
        {
            GoToPoint();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _player.transform.position - transform.position, out hit, 100f))
        {
            if (hit.transform.gameObject == _player)
            {
                if (_mode == Mode.potrul)
                {
                    Invoke("DisableWalkToPlayer", 5);
                }

                _mode = Mode.player;
            }
        }

        if (_mode == Mode.player)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }

    void DisableWalkToPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _player.transform.position - transform.position, out hit, 100f))
        {
            if (hit.transform != null)
            {
                _mode = Mode.potrul;
                GoToPoint();
            }
            else
            {
                Invoke("DisableWalkToPlayer", 5);
            }
        }
    }

    private void GoToPoint()
    {
        _currentPoint = _points[Random.Range(0, _points.Length)];
        _navMeshAgent.SetDestination(_currentPoint.position);
    }
}