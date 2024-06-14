using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    private IEnumerator FishSqawnCo()
    {
        while (true)
        {
            float spawnCoolTime = Random.Range (1.0f, 5.0f);
            yield return new WaitForSeconds (spawnCoolTime);

            Fish fish = PoolManager.Instance.Pop("Fish") as Fish;     
            Debug.Log("spawn");
            
        }
    }

    private void Start()
    {
        StartCoroutine(FishSqawnCo());
    }


}
