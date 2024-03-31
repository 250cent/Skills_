using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];

    public float maxToque;
    public float steeringMax;
    public float angle;
    public float kmh;
    public GameObject detiantion;
    public float minDistance;
    public GameObject gameClear;
    public Transform centerOfMass;
    public GameData gameData;
    
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        PlayToque();
    }

    void PlayToque()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = maxToque * Input.GetAxis("Vertical");
            }
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax + angle;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].steerAngle = 0;
            }
        }
    }
}
