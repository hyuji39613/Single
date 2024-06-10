using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenreManage : MonoBehaviour
{
    public static bool Stoping = false;
    public GameObject stopMenu;
    private void Start()
    {
        stopMenu.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Sea")
        {
            Cursor.visible = false;
            Stoping = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            stopMenu.SetActive(true);
            Stoping = true;
        }
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;

    }
    public void StartBtn()
    {
        Stoping = false;
        stopMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
