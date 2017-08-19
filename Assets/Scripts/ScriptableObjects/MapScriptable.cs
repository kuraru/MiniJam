using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Map", menuName = "ScriptableObjects/Map" )]
public class MapScriptable : ScriptableObject
{
    public char[] map;
    public int Width;
    public int Height;
    public TileScriptable[] Floors;
    public TileScriptable[] Monsters;
    public TileScriptable[] Traps;
}
