using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Transform arrow;
    public Transform playerTransform;
    public Transform[] Objectives;

    public int objectiveIndex = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = playerTransform.InverseTransformPoint(Objectives[objectiveIndex].position);
        float a = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        a += 180;
        arrow.transform.localEulerAngles = new Vector3(0, 180, a);
        
    }
}
