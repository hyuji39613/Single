using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenreManage : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Sea")
        {
            Cursor.visible = false;
           
        }
    }
}
