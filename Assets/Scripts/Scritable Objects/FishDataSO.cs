using UnityEngine;

[CreateAssetMenu(fileName = "FishDataSO", menuName = "Fish/Fish SO")]
public class FishDataSO : ScriptableObject
{
    public Sprite fishSprite;
    public float swimSpeed = 2f;
    public GameObject fishPrefab;
}
