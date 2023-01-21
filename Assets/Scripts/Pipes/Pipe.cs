using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float safeSpawnDistance;
    [SerializeField] private GameObject upperPipe;
    [SerializeField] private float minUpperPipeY;
    [SerializeField] private float maxUpperPipeY;
    public bool IsOnSafeDistanceFromX(float x) =>  x - transform.position.x > safeSpawnDistance;

    public void GeneratePipeDifficulty()
    {
        float randomPosY = Random.Range(minUpperPipeY, maxUpperPipeY);
        upperPipe.transform.localPosition = new Vector3(upperPipe.transform.localPosition.x,
            randomPosY, upperPipe.transform.localPosition.z);
    }
}
