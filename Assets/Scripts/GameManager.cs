using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("GameObject References")]
    [SerializeField] private GameObject p1Ref;
    [SerializeField] private GameObject p2Ref;
    [SerializeField] private GameObject puckRef;

    [Header("Spawn Points")]
    [SerializeField] private Transform p1SpawnPoint;
    [SerializeField] private Transform p2SpawnPoint;
    [SerializeField] private Transform puckSpawnPoint;

    [Header("Player Points")]
    [SerializeField] public float player1Points;
    [SerializeField] public float player2Points;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(bool isPlayer2)
    {
        if (isPlayer2)
        {
            player2Points++;
            Debug.Log("player 2 better");
        }
        else
        {
            player1Points++;
            Debug.Log("player 1 better");
        }

        ResetGame();
        StartCoroutine(BetweenRounds());
    }

    public void ResetGame()
    {
        p1Ref.transform.position = p1SpawnPoint.position;
        //p2Ref.transform.position = p2SpawnPoint.position;

        //puckRef.GetComponent<Rigidbody>().
        puckRef.transform.position = puckSpawnPoint.position;

        puckRef.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        puckRef.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    private IEnumerator BetweenRounds()
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1;
    }
}
