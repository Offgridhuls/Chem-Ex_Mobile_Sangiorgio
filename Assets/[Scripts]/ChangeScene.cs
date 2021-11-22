using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Julian Sangiorgio
//101268880
//2021-11-21
//Goal of this program is to show the functionality of my UI options
public class ChangeScene : MonoBehaviour
{

    public void ChangeToScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}

