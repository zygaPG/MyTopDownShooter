using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField]
    Camera myCamera;

    [SerializeField]
    LayerMask layerMask;

    public Vector3 lookingPosition;

    public Transform targetToRotate;


    void Update()
    {
        MousePositionOnMap();
        SetTargetRotation();
    }


    void MousePositionOnMap()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rayHit, float.MaxValue, layerMask))
        {
            lookingPosition = rayHit.point;
        }
    }

    void SetTargetRotation()
    {
        lookingPosition.y = targetToRotate.position.y;
        targetToRotate.transform.LookAt(lookingPosition);
    }
}
