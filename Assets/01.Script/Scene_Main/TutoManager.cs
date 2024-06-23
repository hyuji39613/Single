using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoManager : MonoBehaviour
{
    [SerializeField] private List<Button> tutoBtnList;
    public static TutoManager instance;
    

    private void Start()
    {
        if (!ItemView.instance.firstStart)
        {
            Destroy(gameObject);
            return;
        }
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
        

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ItemView.instance.firstStart = false;
            Destroy(gameObject);
        }


    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Shop")
        {
            tutoBtnList[1].onClick.AddListener(BtnManager.Instance.CommonRodBtn);
            tutoBtnList[2].onClick.AddListener(BtnManager.Instance.ExitBuyPanel);
        }
    }

    public void Exitbtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void BuyBtn()
    {
        BtnManager.Instance.BuyPanel.SetActive(true);
    }
    public void BuyBtnOff()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        button.SetActive(false);

    }
}
