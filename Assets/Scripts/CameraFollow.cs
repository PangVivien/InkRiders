using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public GameObject T;
    public float speed = 1.5f;
    public int index;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (Target == null)
        {
            FindPlayer();
        }
    }

    void FixedUpdate()
    {
        if (Target == null || T == null) return; // safety check

        this.transform.LookAt(Target.transform);
        float car_Move = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position, T.transform.position, car_Move * Time.deltaTime);
    }

    void FindPlayer()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        T = GameObject.FindGameObjectWithTag("Target");
    }
}
