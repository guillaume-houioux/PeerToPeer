using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    
    public void btn_load_scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
