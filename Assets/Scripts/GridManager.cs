using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridManager : MonoBehaviour {
    public char[] map;
    public int width;
    public float scale;
    public Transform parent;

    public static event UnityAction OnCreateGrid;

    [SerializeField] private MapScriptable _map;

    public MapScriptable Map
    {
        get { return _map; }
        set { _map = value;
            CreateGrid( );
        }
    }
    

    private List<Tile> _tileMap = new List<Tile>();

    [SerializeField]    private Tile TilePrefab;
    PoolObjectContainer _pool;
    Camera _camera;


	// Use this for initialization
	void Awake () {
        _pool = GetComponent<PoolObjectContainer>( );
        _pool.Init( TilePrefab.gameObject, this.transform, 10 );
        _camera = Camera.main;
    }

    private void Start()
    {
        CreateGrid( );
    }

    public void CreateGrid()
    {
        if(OnCreateGrid != null)
            OnCreateGrid.Invoke( );
        _tileMap.Clear( );
        var capacity = _map.Width * _map.Height;
        var camPos = _camera.transform.localPosition;
        camPos.x = (float)_map.Width / 2;
        camPos.y = (float)_map.Height / 2;
        _camera.transform.localPosition = camPos;
        _tileMap.Capacity = capacity;
        
        for(var x = 0; x < _map.Width; x++ )
        {
            for(var y=0; y< _map.Height; y++ )
            {
                var tileObj = _pool.Get();
                tileObj.transform.localPosition = new Vector2( x, y );
                tileObj.SetActive( true );
                var tile = tileObj.GetComponent<Tile>();
                if(_map.map != null)
                {
                    var mapPos = x +_map.Width * y;
                    TileScriptable tileInfo = null;
                    switch(_map.map[mapPos])
                    {
                        case 'M':
                            tileInfo = _map.Monsters.Random( );
                            break;
                        case 'T':
                            tileInfo = _map.Traps.Random( );
                            break;
                        default: //Floor
                            tileInfo = _map.Floors.Random( );
                            break;

                    }
                    tile.SetTile(x, y, tileInfo );
                    
                }
            }
        }
    }
}
