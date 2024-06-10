using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/FishData")]
public class FishDataSo : ScriptableObject
{
    public FishEnum fishEnum;

    public float speed;
    public Sprite fishSprite;

    public float minY, maxY;
}