using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera OrthoG;
    [SerializeField] private float sensivity;
    [SerializeField] private int speed;
    [SerializeField] private Animator playerAnimator;

    private Rigidbody rigidBody;
    private Vector3 mousePosition;
    private Vector3 firstPosition;
    private Vector3 difference;
    private void Awake()
    {
        rigidBody = transform.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        AnimationManager.Instance.PlayAnimation(playerAnimator, AnimationState.Running);
        rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, new Vector3(difference.x, rigidBody.velocity.y, speed), 11.2f);
    }

    void Update()
    {
        firstPosition = Vector3.Lerp(firstPosition, mousePosition, .1f);

        if (Input.GetMouseButtonDown(0))
            MouseDown(Input.mousePosition);

        else if (Input.GetMouseButtonUp(0))
            MouseUp();

        else if (Input.GetMouseButton(0))
            MouseHold(Input.mousePosition);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);
    }

    //END LINE.
    private void MouseDown(Vector3 inputPos)
    {
        mousePosition = OrthoG.ScreenToWorldPoint(inputPos);
        firstPosition = mousePosition;
    }
    private void MouseHold(Vector3 inputPos)
    {
        mousePosition = OrthoG.ScreenToWorldPoint(inputPos);
        difference = mousePosition - firstPosition;
        difference *= sensivity;
    }
    private void MouseUp()
    {
        difference = Vector3.zero;
    }
}
