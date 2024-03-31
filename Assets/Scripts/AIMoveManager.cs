using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveManager : MonoBehaviour
{
    private bool isstop;
    public WayPoint WayPoint;
    public List<Transform> nodes = new List<Transform>();
    public Transform currentWayPoint;
    public int currentNum = 0;

    [Range(0, 20)] 
    public float steerForce;
    public float minDistance = 5;
    
    public float vertical = 3;
    public float horizontal;
    
    
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];

    public float maxToque;
    public float steeringMax;
    public float angle;
    public float kmh;
    public GameObject detiantion;
    public GameObject gameClear;
    public Transform centerOfMass;
    public GameData gameData;
    
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;

        for (int i = 0; i < WayPoint.transform.childCount; i++)
        {
            nodes.Add(WayPoint.transform.GetChild(i));
        }

        currentNum = 0;
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);
    }

    private void FixedUpdate()
    {
        PlayToque();
        AISteer();
        CalMinDistanceWayPoint();
    }

    void PlayToque()
    {
        if (vertical != 0)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = maxToque * vertical;
            }
        }

        if (horizontal != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = horizontal * steeringMax + angle;
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

    void AISteer()
    {
        Vector3 relative = transform.InverseTransformPoint(nodes[currentNum].position);
        relative /= relative.magnitude;
        horizontal = (relative.x / relative.magnitude) * steerForce;
    }

    void CalMinDistanceWayPoint()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                new Vector2(nodes[currentNum].position.x, nodes[currentNum].position.z)) < minDistance)
        {
            currentNum++;
        }

        if (!isstop)
        {
            if (nodes.Count <= currentNum)
            {
                isstop = true;
            }
        }
    }
}
