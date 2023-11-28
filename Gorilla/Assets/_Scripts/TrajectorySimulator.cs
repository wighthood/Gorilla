using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectorysimulator : MonoBehaviour
{

    [Range(-10, 10)] public float Windforce;
    [Range(1, 20)] public float Gravity;

    public GameObject SpeedGizmo;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = SpeedGizmo.transform.position - transform.position;
        Vector3 pCur = transform.position;

        for(int i =0; i<1000;++i)
        {
            if (pCur.y < 0.0f)
                break;
            v += (Windforce * Vector3.right + Gravity * Vector3.down) * Time.fixedDeltaTime;
            Vector3 pNext = pCur + v * Time.fixedDeltaTime;

            Debug.DrawLine(pCur, pNext);

            pCur = pNext;
        }
    }
}
