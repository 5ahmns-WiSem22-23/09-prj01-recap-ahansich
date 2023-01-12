using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSceneManager : MonoBehaviour
{
    // Die minimale range
    [SerializeField]
    float minRange;

    // Die maximale range
    [SerializeField]
    float maxRange;

    // Für das PickUp Object
    [SerializeField]
    GameObject pickUp;


    [SerializeField]
    Text itemCounter;

    [SerializeField]
    Text timeDisplay;

    // Ich erstelle eine public Variable mit Integer Werten
    public static int pickUpCount;

    // Variable für die Zeit
    float time;


    [SerializeField]
    float maxTime;

    // In der Start FUnktion wird ein PickUp gespawned
    void Start()
    {
        SpawnItem();
    }

    private void Update()
    {
        // In der Update Funktion werden die schon gesammeltenPickUps gezählt. Mir wird angezeigt wie viele ich schon gesammelt habe
        itemCounter.text = pickUpCount.ToString();
        // Zum Anzeigen der Zeit
        time += Time.deltaTime;

        // Wenn die Zeit erreicht wurde, wird die Szene erneut geladen und alles auf 0/Anfang gesetzt
        if (time >= maxTime)
        {
            SceneManager.LoadScene(0);
            pickUpCount = 0;
        }

        // Die Zeit zählt von der maximalen Zeit runter auf 0
        timeDisplay.text = Mathf.Round(maxTime - time).ToString() + "sec.left";
        itemCounter.text = "Score: " + pickUpCount.ToString();
    }

    public void SpawnItem()
    {
        Instantiate(pickUp, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
