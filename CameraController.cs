using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private Transform target;

    private float y = 5.25f;
    private float z = 10f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void FixedUpdate()
    {
        //transform.position = new Vector3(target.position.x + 2.5f, target.position.y + 5.25f, target.position.z - 10);
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + 2.5f, target.position.y + y, target.position.z - z), .01f);
    }

    public void SetTarget(Transform target, bool up)
    {
        this.target = target;
        if (up)
        {
            y += 1f;
            z += 1f;
        }
        else
        {
            y -= 1f;
            z -= 1f;
        }
    }
}