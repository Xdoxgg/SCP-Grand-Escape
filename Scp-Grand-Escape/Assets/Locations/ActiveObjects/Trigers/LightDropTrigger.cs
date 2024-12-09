using System;
using UnityEngine;
using System.Timers;

public class LightDropTrigger : MonoBehaviour
{
    [SerializeField] private DoorController _doorController1;
    [SerializeField] private DoorController _doorController2;
    private bool _start = false;
    private Timer _timer;
    private bool _flag = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _light2;

    void Start()
    {
        _timer = new Timer(400);
        _timer.Elapsed += TimerElapsed;
        _timer.AutoReset = false;
    }

    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        _start = true;
    }


    void Update()
    {
        if (!_flag && (_doorController1.DoorOpen || _doorController2.DoorOpen))
        {
            _timer.Start();
        }

        if (_start)
        {
            _animator.SetBool("Start", true);
            _flag = true;
            _start = false;
            _light.SetActive(false);
            _light2.SetActive(false);
        }
    }
}