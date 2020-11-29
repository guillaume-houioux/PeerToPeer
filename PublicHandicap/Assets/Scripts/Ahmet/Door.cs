using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool allowPerson;
    public bool allowWheelchair;
    public bool allowBlind;
    public bool allowDeaf;
    public bool allowColorBlind;
    public bool isWorking = false;

    public DoorManager doorManager;
}
