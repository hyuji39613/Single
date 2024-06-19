using System.Collections;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    [SerializeField] private float spawnCoolMin, spawnCoolMax;
    [SerializeField] private int ranMin, ranMax;

    private IEnumerator FishSqawnCo()
    {
        while (true)
        {
            float spawnCoolTime = Random.Range(spawnCoolMin, spawnCoolMax);
            yield return new WaitForSeconds(spawnCoolTime);
            int ranNum = Random.Range(ranMin, ranMax);
            switch (ranNum)
            {
                case 0:
                    Fish fish = PoolManager.Instance.Pop("Anchovy") as Fish;
                    break;
                case 1:
                    fish = PoolManager.Instance.Pop("Mackerel") as Fish;
                    break;
                case 2:
                    fish = PoolManager.Instance.Pop("StarFish") as Fish;
                    break;
                case 3:
                    fish = PoolManager.Instance.Pop("BlueFish") as Fish;
                    break;
                case 4:
                    fish = PoolManager.Instance.Pop("StoneFish") as Fish;
                    break;
                case 5:
                    fish = PoolManager.Instance.Pop("PufferFish") as Fish;
                    break;
                case 6:
                    fish = PoolManager.Instance.Pop("WhiteDongari") as Fish;
                    break;
                case 7:
                    fish = PoolManager.Instance.Pop("Bluetang") as Fish;
                    break;
                case 8:
                    fish = PoolManager.Instance.Pop("Shark") as Fish;
                    break;
                case 9:
                    fish = PoolManager.Instance.Pop("SunFish") as Fish;
                    break;
            }
        }
    }
    private void Start()
    {

        StartCoroutine(FishSqawnCo());
    }


}
