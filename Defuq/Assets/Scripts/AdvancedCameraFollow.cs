using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    float x;
    float z;
    [SerializeField] float zOffset;
    Vector3 cameraPosition;

    private void Start()
    {
        cameraPosition = Camera.main.transform.position;
        x= cameraPosition.x;
        z = cameraPosition.z;
    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        x += (target.transform.position.x - x) * 0.05f;//moves 5 precents closer towards our target(player) x axis
        z += (target.transform.position.z - z) * 0.05f;//moves 5 precents closer towards our target(player) z axis
        cameraPosition = new Vector3(x, cameraPosition.y, z - zOffset);
        Camera.main.transform.position = cameraPosition*Time.timeScale;//incase we want to pause the game(default equals 1)
    }
}
