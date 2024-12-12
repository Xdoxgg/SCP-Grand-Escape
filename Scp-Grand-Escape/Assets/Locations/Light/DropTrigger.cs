using UnityEngine;
using System.Timers;

public class DropTrigger : MonoBehaviour
{
    [SerializeField] private DoorController _doorController1;
    [SerializeField] private DoorController _doorController2;
    [SerializeField] private GameObject[] _offItems;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _time;
    private bool _drop = false;
    private Timer _timer;

    void Start()
    {
        _timer = new Timer(_time);
        _timer.AutoReset = false;
        _timer.Elapsed += TimerElapsed;


    }


    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        _drop = true;
    }

    void Update()
    {

        if (!_drop && (_doorController1.DoorOpen || _doorController2.DoorOpen))
        {
            _timer.Start();
        }

        if (_drop)
        {
            foreach (GameObject item in _offItems)
            {
                item.SetActive(false);
            }
         _animator.SetBool("Start", true);   
        }
    }
    
}