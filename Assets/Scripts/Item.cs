using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotTag {None, Head, Chest, Legs, Feet }

[CreateAssetMenu(menuName ="Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public GameObject gameObject;
    public SlotTag itemTag;

    [Header("If the item can be equipped")]
    public GameObject equimentPrefab;
}
