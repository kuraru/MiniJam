using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    [SerializeField] MapScriptable[] _maps;
    GridManager _gridManager;
    int currentMap = 0;
    private void Awake()
    {
        _gridManager = GetComponent<GridManager>( );
    }

    public void NextMap()
    {
        currentMap++;
        currentMap %= _maps.Length;
        var map = _maps[currentMap];
        _gridManager.Map = map;
    }

}
