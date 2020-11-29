using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject cameraBot;
    [SerializeField] private GameObject cameraTop;
    [SerializeField] private Canvas HUD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoUp()
    {
        cameraBot.SetActive(true);
        HUD.worldCamera = cameraBot.GetComponent<Camera>();
        cameraTop.SetActive(false);
    }

    public void GoDown()
    {
        cameraTop.SetActive(true);
        HUD.worldCamera = cameraTop.GetComponent<Camera>();
        cameraBot.SetActive(false);
    }
}
