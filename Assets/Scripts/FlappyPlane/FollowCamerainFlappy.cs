using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamerainFlappy : MonoBehaviour
{
    public Transform Target;

    float offsetX;

     void Start()
    {
        if (Target == null)
            return;

        offsetX = transform.position.x - Target.position.x;
    }

     void Update()
    {
        if(Target == null) return;

        Vector3 pos = transform.position;
        pos.x = Target.position.x + offsetX;
        transform.position = pos;
    }
}
