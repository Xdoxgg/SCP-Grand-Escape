using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Timers;

public class SCP049 : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField]private Playerstats _stats;
    [SerializeField] private DoorTrigger _trigger;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Playerstats _playerstats;
    private bool _readyToHit = true;
    private float _damage=50f;
    private Timer _timer;

    void Start()
    {
        _timer = new Timer(1500);
        _timer.AutoReset = false;
        _timer.Elapsed += TimerElapsed;
    }

    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        _readyToHit = true;
    }
    
    void Update()
    {
        if (_playerstats.Health > 0)
        {
            if (!_trigger.Ready)
            {
                _agent.isStopped = true;
            }
            else
            {
                _agent.isStopped = false;
            }

            if (_readyToHit && (transform.position - _player.transform.position).magnitude < 2f)
            {
                Hit();

            }
        }
        else
        {
            _agent.isStopped = true;
        }


    }

    void Hit()
    {
        _readyToHit = false;
        _stats.Health -= _damage;
        
        
        _timer.Start();
    }
}