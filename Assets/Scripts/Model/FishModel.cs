using UnityEngine;

public class FishModel
{
    public GameObject Prefab { get; private set; }
    public Sprite Sprite { get; private set; }
    public float Speed { get; private set; }
    public SwimDirection Direction { get; private set; }

    public FishModel(FishDataSO data, SwimDirection direction)
    {
        Prefab = data.fishPrefab;
        Sprite = data.fishSprite;
        Speed = data.swimSpeed;
        Direction = direction;
    }
}
