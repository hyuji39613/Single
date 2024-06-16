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
                SceneManager.LoadScene("SeaInfo");

            }
        }
       
        if (collision.gameObject.CompareTag("Shop"))
        {
            SceneManager.LoadScene("Shop");
        }
    }
}
