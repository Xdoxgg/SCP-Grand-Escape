using UnityEngine;
using UnityEngine.UIElements;
using System.Timers;


public class SCP914 : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _object;
    [SerializeField] private PlatformEnter _platformEnter;
    [SerializeField] private PlatformEnd _platformEnd;
    [SerializeField] private UsefulItem _usefulItem;
    [SerializeField] Animator _doorAnimation1;
    [SerializeField] Animator _doorAnimation2;
    [SerializeField] private Timer _timer;
    private bool _endTimer = false;

    void Update()
    {
        if (_endTimer)
        {
            _doorAnimation1.SetBool("IsOpen", false);
            _doorAnimation2.SetBool("IsOpen", false);
            _endTimer = false;
        }
    }

    public SCP914()
    {
        _timer = new Timer(10000);
        _timer.AutoReset = false;

        _timer.Elapsed += DoorTimerElapsed;
    }

    public void DoorTimerElapsed(object sender, ElapsedEventArgs e)
    {
        
        _endTimer = true;
    }

    

    public void Interact()
    {
        if (_platformEnter.UsefulItem != null)
        {
            
            _doorAnimation1.SetBool("IsOpen", true);
            _doorAnimation2.SetBool("IsOpen", true);
            _timer.Start();
           
            _usefulItem = _platformEnter.UsefulItem;
            _platformEnter.UsefulItem = null;
            _usefulItem.UpdateLavel();

            _platformEnd.UsefulItem = _usefulItem;
        }
        
       
    }

    public string GetDesciption()
    {
        return "Activate";
    }

    public bool IsInventereble()
    {
        return false;
    }
}