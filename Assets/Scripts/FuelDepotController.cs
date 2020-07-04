using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelDepotController : MonoBehaviour
{
   
    #region Private Variables
    
    private float _fuel = 10f;
    private float _refuelRate = 0.1f;
    
    #endregion
    
    #region Public Variables
    
    public float depotFuel => _fuel;
    public float fuelTransferRate => _refuelRate;

    #endregion

    public void EmptyTank()
    {
        _fuel = 0f;
    }
}