using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;

    public GameObject entrance;
    public GameObject exit;

    public bool CommonCanPass = false;
    public bool wheelsCanPass = false;
    public bool BlindCanPass = false;
    public bool DeafCanPass = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ObstacleType
{
    DOORS,
    DOORXL,
    STAIRS,
    RAMP,

}
