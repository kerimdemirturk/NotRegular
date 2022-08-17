using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carsMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float currentTurnAngle;
    private float currentBreakForce;
    private bool isBrake;

    [SerializeField] private float speedForce;
    [SerializeField] private float maxTurnAngle;
    [SerializeField] private float breakForce;

    //Wheel Collliders
    public WheelCollider frontRightCol;
    public WheelCollider frontLeftCol;
    public WheelCollider rearRightCol;
    public WheelCollider rearLeftCol;

    // Wheel transforms
    public Transform frontRightTra;
    public Transform frontLeftTra;
    public Transform rearRightTra;
    public Transform rearLeftTra;

    void FixedUpdate()
    {
        carMovement();
        UpdateWheel();
    }

    private void carMovement()
    {
        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBrake = Input.GetKey(KeyCode.Space);

        //Give power to wheels
      
        frontRightCol.motorTorque = verticalInput * speedForce;
        frontLeftCol.motorTorque = verticalInput * speedForce;

        //break
        currentBreakForce = isBrake ? breakForce : 0f;
        frontLeftCol.brakeTorque = currentBreakForce;
        frontRightCol.brakeTorque = currentBreakForce;
        rearRightCol.brakeTorque = currentBreakForce;
        rearLeftCol.brakeTorque = currentBreakForce;
        
        //rotate wheels
        currentTurnAngle = maxTurnAngle * horizontalInput;
        frontRightCol.steerAngle = currentTurnAngle;
        frontLeftCol.steerAngle = currentTurnAngle;
    }


    private void WheelTurn(WheelCollider wheelcollider,Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelcollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }

    private void UpdateWheel()
    {
        WheelTurn(frontRightCol, frontRightTra);
        WheelTurn(frontLeftCol, frontLeftTra);
        WheelTurn(rearRightCol, rearRightTra);
        WheelTurn(rearLeftCol, rearLeftTra);
    }

}
