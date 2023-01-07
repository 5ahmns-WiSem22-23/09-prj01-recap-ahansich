using UnityEngine;

public class SceneManager : MonoBehaviour
{

    [SerializeField]
    float minRange;
    [SerializeField]
    float maxRange;
    [SerializeField]
    GameObject pickUp;

    public static int pickUpCount;

    void Start()
    {
         SpawnItem();
    }

    public void SpawnItem()
    {
        Instantiate(pickUp, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
