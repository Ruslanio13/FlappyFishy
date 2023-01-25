using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float safeSpawnDistance;
    [SerializeField] private GameObject upperPipe;
    [SerializeField] private float minUpperPipeY;
    [SerializeField] private float maxUpperPipeY;
    [SerializeField] private GameObject money;
    public bool IsOnSafeDistanceFromX(float x)
    {
        return x - transform.position.x > safeSpawnDistance;
    }
    public void GeneratePipe()
    {
        GeneratePipeDifficulty();
        GenerateMoney();
    }

    public void GeneratePipeDifficulty()
    {
        float randomPosY = Random.Range(minUpperPipeY, maxUpperPipeY);
        upperPipe.transform.localPosition = new Vector3(upperPipe.transform.localPosition.x,
            randomPosY, upperPipe.transform.localPosition.z);
    }

    private void GenerateMoney()
    {
        money.SetActive(true);
        if (money.TryGetComponent(out Money m))
            m.GenerateMoneyPosition();
    }
}