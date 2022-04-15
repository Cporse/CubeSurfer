using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public static ObjectController Instance;

    [SerializeField] private GameObject targetPosition;
    [SerializeField] private Camera uiCamera;

    public GameObject TargetPosition { get => targetPosition; set => targetPosition = value; }
    public Camera UiCamera { get => uiCamera; set => uiCamera = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
