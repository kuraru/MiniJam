using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    [SerializeField] int posX = 0;
    [SerializeField] int posY = 0;
    [SerializeField] bool isActive = false;
    [SerializeField] TileScriptable _tileInfo;

    SpriteRenderer _renderer;
	// Use this for initialization
	void Awake () {
        _renderer = GetComponent<SpriteRenderer>( );
       
	}

    private void OnEnable()
    {
        GridManager.OnCreateGrid += OnCreateGrid;
    }
    private void OnDisable()
    {
        GridManager.OnCreateGrid -= OnCreateGrid;
    }

    private void OnCreateGrid()
    {
        gameObject.SetActive( false );
    }

    public void SetTile(int x, int y, TileScriptable tileInfo)
    {
        posX = x;
        posY = y;
        _tileInfo = tileInfo;
        _renderer.sprite = _tileInfo.Sprite;

    }

    public void Tint(float tint)
    {

    }
}
