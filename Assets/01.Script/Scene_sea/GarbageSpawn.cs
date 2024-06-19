using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawn : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GarbageBagSpawn());
        StartCoroutine(PlCupSpawn());
        StartCoroutine(PotSpawn());
        StartCoroutine(GlassCupSpawn());
    }
    private IEnumerator GarbageBagSpawn()
    {
        float ranTime = Random.Range(10f,20f);
        yield return new WaitForSeconds(ranTime);
        Fish fish = PoolManager.Instance.Pop("GarBag") as Fish;
        StartCoroutine(GarbageBagSpawn());
    }
    private IEnumerator PlCupSpawn()
    {
        float ranTime = Random.Range(10f, 20f);
        yield return new WaitForSeconds(ranTime);
        Fish fish = PoolManager.Instance.Pop("PlCup") as Fish;
        StartCoroutine(PlCupSpawn());
    }
    private IEnumerator PotSpawn()
    {
        float ranTime = Random.Range(20f, 30f);
        yield return new WaitForSeconds(ranTime);
        Fish fish = PoolManager.Instance.Pop("Pot") as Fish;
        StartCoroutine(PotSpawn());
    }
    private IEnumerator GlassCupSpawn()
    {
        float ranTime = Random.Range(30f, 40f);
        yield return new WaitForSeconds(ranTime);
        Fish fish = PoolManager.Instance.Pop("GlassCup") as Fish;
        StartCoroutine(GlassCupSpawn());
    }
}
