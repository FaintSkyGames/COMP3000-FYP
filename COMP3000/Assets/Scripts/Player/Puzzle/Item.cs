using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        puzzlePiece,
        health,
        ammo
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.puzzlePiece:      return ItemAssets.Instance.puzzleSprite;
            case ItemType.health:           return ItemAssets.Instance.healthPackSprite;
            case ItemType.ammo:             return ItemAssets.Instance.ammoSprite;
        }
    }

}
