using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;


public class Playerstats : MonoBehaviour
{
    //[SerializeField]
    //private float _healthState;
    [SerializeField]
    private float _staminaState;
    private bool _readyToRun;
    [SerializeField]
    private MovingControl _player;
    private System.Timers.Timer _runCoolDown;


    void Start()
    {
        _runCoolDown = new System.Timers.Timer();
        _staminaState = 100.0f;
       // _healthState = 100.0f;
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
