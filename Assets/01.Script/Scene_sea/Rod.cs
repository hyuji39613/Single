using DG.Tweening;
using TreeEditor;
using UnityEngine;

public class Rod : MonoBehaviour
{
    float minLimit = 1;
    float maxLimit = 11;
    float speed = 0.2f;
    void Update()
    {
        if (ScenreManage.Stoping) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOScaleX(1, 0.3f).SetEase(Ease.InOutQuad);
        }
            Vector2 wheelInput = Input.mouseScrollDelta;
        if (wheelInput.y > 0)
        {
            transform.localScale += new Vector3(speed, 0, 0);
        }
        else if (wheelInput.y < 0)
        {
            transform.localScale -= new Vector3(speed, 0, 0);
    
        }
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, minLimit, maxLimit), transform.localScale.y, transform.localScale.z);
    }

    

}
