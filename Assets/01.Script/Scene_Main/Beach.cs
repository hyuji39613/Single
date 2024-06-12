using UnityEngine;
using UnityEngine.SceneManagement;



public class Beach : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            //PcPosition.instance.SceneChange();
            SceneManager.LoadScene("SeaInfo");

        }
        if (collision.gameObject.CompareTag("Shop"))
        {
            //PcPosition.instance.SceneChange();
            SceneManager.LoadScene("Shop");
        }
    }


    private void Update()
    {
        
    }
}
