using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "TileScriptable", menuName = "ScriptableObjects/TileScriptable" )]
public class TileScriptable : ScriptableObject
{

    public Sprite Sprite;
    public string Name;
    public TileType Type;
    
}
