using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{

    [SerializeField]
    private GameObject _object;
    public bool startMove;
    [SerializeField]
    private Vector3 _positionStart;
    [SerializeField]
    private Vector3 _positionEnd;
    private int _position;

    void Start()
    {
		startMove=false;
        _position=0;//0 - start, 1 - end

	}


    void Update()
    {
        if (startMove)
        {
            if (_position == 0)
            {
                transform.position = GoDown(transform.position);
                if (transform.position.y < _positionEnd.y)
                {
                    _position = 1;
                    startMove = false;
                }
            }
            else
            {
				transform.position = GoUp(transform.position);
				if (transform.position.y > _positionStart.y)
				{
					_position = 0;
					startMove = false;
				}
			}


            
        }
    }
    private Vector3 GoDown(Vector3 pos)
    {
        pos.y -= 0.5f*Time.deltaTime;

        return pos;
    }
	private Vector3 GoUp(Vector3 pos)
	{
		pos.y += 0.5f * Time.deltaTime;

		return pos;
	}
}
