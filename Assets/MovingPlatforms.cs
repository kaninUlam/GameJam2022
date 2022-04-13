using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float _speed;
    public int _startingPoint;
    public Transform[] points;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[_startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if(i == points.Length)
                {
                    i = 0;
                }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, _speed * Time.deltaTime);
    }
}
