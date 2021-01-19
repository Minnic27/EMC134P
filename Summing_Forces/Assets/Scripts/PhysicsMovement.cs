using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    public Vector3 velocityVector;
    public Vector3 netForceVector;
    public bool netForceCheck;
    public List<Vector3> forceVectorList = new List<Vector3>();

    
    void FixedUpdate()
    {
        AddForces();
        if(netForceVector == Vector3.zero) {
            transform.position += velocityVector * Time.deltaTime;
            netForceCheck = true;
        } else {
            Debug.LogError("Unbalanced Force Detected!");
            netForceCheck = false;
        }
    }

    void AddForces() {
        netForceVector = Vector3.zero;

        foreach (Vector3 forceVector in forceVectorList) {
            netForceVector += forceVector;
        }

    }
}
