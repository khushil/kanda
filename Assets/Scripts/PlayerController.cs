using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    #region Private Variables

    private Rigidbody _rigidBody;

    #endregion

    #region Public Variables

    [SerializeField] private float fuel = 10f;
    [SerializeField] private float mainEngineThrust = 10f;
    [SerializeField] private float rcsThrust = 10f;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("FuelDepot"))
        {
            fuel += collision.gameObject.GetComponent<FuelDepotController>().depotFuel;
            collision.gameObject.GetComponent<FuelDepotController>().EmptyTank();
            Debug.Log("Current Vehicle Fuel =" + fuel);
            Debug.Log("CUrrent Depot Fiel = " + collision.gameObject.GetComponent<FuelDepotController>().depotFuel );
        }

    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidBody.AddRelativeForce(Vector3.up * (mainEngineThrust * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * (rcsThrust * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * (rcsThrust * Time.deltaTime));
        }
        
        
        // Probably don't need this but it's fun for now
        if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            _rigidBody.AddRelativeForce(Vector3.back,ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q))
        {
            _rigidBody.AddRelativeForce(Vector3.forward,ForceMode.Impulse);
        }
    }
}
