using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySeek : Action // this mission is call by behavior designer action
{
    public float speed;
    public float arriveDistance = 0.1f;
    private float sqearriveDistance;
    public SharedTransform target;

    public override void OnStart()
    {
        sqearriveDistance = arriveDistance * arriveDistance;
    }

    public override TaskStatus OnUpdate() // sync with unity OnUpdate
    {
        if (target == null || target.Value == null)
        {
            return TaskStatus.Failure;// Failure is behavior designer action 's enum
        }


        transform.LookAt(target.Value.position);
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        if ((target.Value.position - transform.position).sqrMagnitude < sqearriveDistance) 
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;

    }
}
