using UnityEngine;
using UnityEngine.SceneManagement;



public class Beach : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ItemView.instance.rodData!= null) 
        {
            if (collision.gameObject.CompareTag("Sea"))
            {
                PcPosition.instance.inSea = true;
                SceneManager.LoadScene("Sea");
                Time.timeScale = 1f;
            }
        }
       
        if (collision.gameObject.CompareTag("Shop"))
        {
            PcPosition.instance.inShop = true;
            SceneManager.LoadScene("Shop");
        }
    }
}
