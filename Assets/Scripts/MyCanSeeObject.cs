using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCanSeeObject : Conditional
{
    public Transform[] targets; // it will be Multiple target
    public float filedOfViewAngle = 90;
    public float viewDistance = 7;
    public SharedTransform seeTarget;

    public override TaskStatus OnUpdate()
    {
        if(targets == null)
        {
            return TaskStatus.Failure;
        }
        foreach(var target in targets)
        {
            float distance = (target.position - transform.position).magnitude;
            float angle = Vector3.Angle(transform.forward, target.position - transform.position);
            if(distance<viewDistance && angle<filedOfViewAngle*0.5f)
            {
                this.seeTarget.Value = target;
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
