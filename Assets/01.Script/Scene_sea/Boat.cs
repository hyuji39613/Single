using UnityEngine;

public class Boat : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position -= new Vector3(1, 0, 0) * 1.5f * Time.deltaTime;
            Camera.main.transform.position -= new Vector3(1, 0, 0) * 0.6f * Time.deltaTime;
        }
        if (Input.GetMouseButton(1))
        {
            transform.position += new Vector3(1, 0, 0) * 1.5f * Time.deltaTime;
            Camera.main.transform.position += new Vector3(1, 0, 0) * 0.6f * Time.deltaTime;
        }
        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, -1, 1),
               Mathf.Clamp(Camera.main.transform.position.y, -31, 0), Camera.main.transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), transform.position.y, transform.position.z);
    }
}
