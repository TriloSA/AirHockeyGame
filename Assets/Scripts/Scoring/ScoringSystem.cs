using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private bool isPlayer2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puck")
        {
            GameManager.Instance.Score(isPlayer2);
        }
    }
}
