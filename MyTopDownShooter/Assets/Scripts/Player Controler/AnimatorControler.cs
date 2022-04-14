using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    [SerializeField]
    Animator aimator;



    int xAxisHash;
    int yAxisHash;

    void Start()
    {
        xAxisHash       = Animator.StringToHash("Xaxis");
        yAxisHash       = Animator.StringToHash("Yaxis");
    }

 

    public void SetAxis(Vector3 axis)
    {
        float xxx = Vector3.Dot(axis.normalized, transform.right);
        float yyy = Vector3.Dot(axis.normalized, transform.forward);

        aimator.SetFloat(xAxisHash, xxx, 0.1f, Time.fixedDeltaTime);
        aimator.SetFloat(yAxisHash, yyy, 0.1f, Time.fixedDeltaTime);
    }

}
