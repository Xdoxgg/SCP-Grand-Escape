using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;


public class Playerstats : MonoBehaviour
{
    [SerializeField]
    private float _healthState;
    [SerializeField]
    private float _staminaState;
    private bool _readyToRun;
    [SerializeField]
    private MovingControl _player;
    private System.Timers.Timer _runCoolDown;
    [SerializeField] private Rigidbody _rigidbody;

    public float Health
    {
        get { return _healthState; }
        set { _healthState = value; }
    }
    
    void Start()
    {
        _runCoolDown = new System.Timers.Timer();
        _healthState = 100f;
        _staminaState = 100.0f;
        _runCoolDown.Interval = 5000;
        _runCoolDown.Elapsed += OnTimedEvent;
        _readyToRun = true;
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        _readyToRun = true;
    }

    private void Update()
    {
        if (_healthState > 0)
        {
            if (_staminaState < 20)
            {
                _readyToRun = false;
                _runCoolDown.Start();
            }

            if (_player.Runing && _readyToRun)
            {
                _staminaState -= 10 * Time.deltaTime;
            }

            if (!_player.Runing)
            {
                if (_staminaState + (2 * Time.deltaTime) <= 100)
                {
                    _staminaState += 2 * Time.deltaTime;
                    if (_staminaState >= 99f)
                    {
                        _staminaState = 100f;
                    }
                }
            }
        }
        else
        {
            _rigidbody.useGravity = true;
            _rigidbody.freezeRotation = false;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.None;
        }
    }



    public bool ReadyToRun
    {

        get { return _readyToRun; }
        set { _readyToRun = value; }
    }

    //public float Stamina
    //{
    //    get { return _staminaState; }
    //    set { _staminaState = value; }
    //}
}