using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosY;
    [SerializeField] private float maxPosY;
    public void GenerateMoneyPosition()
    {
        float randomPosX = Random.Range(minPosX, maxPosX);
        float randomPosY = Random.Range(minPosY, maxPosY);
        transform.localPosition = new (randomPosX, randomPosY, transform.localPosition.z);
    }
}
