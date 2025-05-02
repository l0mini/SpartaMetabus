using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;

    Vector2 minpos = new Vector2(-8.6f,-13.2f);
    Vector2 maxpos = new Vector2(8.6f,13.2f);

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;

        pos.x = Mathf.Clamp(pos.x, minpos.x, maxpos.x);
        pos.y = Mathf.Clamp(pos.y, minpos.y, maxpos.y);

        transform.position = pos;
    }
}
