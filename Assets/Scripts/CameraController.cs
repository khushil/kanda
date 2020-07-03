using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Variables
    
    [SerializeField] GameObject cameraTarget;
    
    #endregion
    
    #region Private Variables
    
    private Vector3 offsetToPlayer;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        offsetToPlayer = transform.position - cameraTarget.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cameraTarget.transform.position + offsetToPlayer;
    }
}