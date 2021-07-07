using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspetosManager : MonoBehaviour
{

    [SerializeField] private SliderJoint2D espeto = default;
    [SerializeField] private JointMotor2D auxMotor = default;

    // Start is called before the first frame update
    void Start()
    {
        auxMotor = espeto.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(espeto.limitState == JointLimitState2D.UpperLimit)
        {
            auxMotor.motorSpeed = Random.Range(-1, 1);
            if ((int)auxMotor.motorSpeed != 0) espeto.motor = auxMotor;

        }
        
        if(espeto.limitState == JointLimitState2D.LowerLimit)
        {
            auxMotor.motorSpeed = Random.Range(1, 5);
            if((int)auxMotor.motorSpeed != 0) espeto.motor = auxMotor;

        }
    }
}
