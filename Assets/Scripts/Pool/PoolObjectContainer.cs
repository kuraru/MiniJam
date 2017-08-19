using System.Collections.Generic;
using UnityEngine;

public class PoolObjectContainer: MonoBehaviour 
{
    [SerializeField] GameObject _template = null;
    [SerializeField] Transform _parent;
    [SerializeField] int _count = 1;

    private readonly Queue<GameObject> _poolQueue = new Queue<GameObject>();

    private void Awake()
    {
        if(_template != null)
        {
            Init( _template, _parent, _count );
        }
    }

    public void Init(GameObject gameObject, Transform parent = null, int count = 1)
    {
        _parent = parent;
        if( parent == null )
            _parent = transform;
        
        count = Mathf.Max( count, 1 );
        _template = gameObject;
        _template = CreateObject( );
        _poolQueue.Enqueue( _template );
        for(var i = 1; i< count; ++i )
        {
            _poolQueue.Enqueue( CreateObject());
        }
    }

    public GameObject Get()
    {
        if(_poolQueue.Count > 0)
        {
            var obj = _poolQueue.Dequeue();
            if(!obj.activeSelf)
                return obj;
        }
            return CreateObject( );
        
    }
 
    private GameObject CreateObject()
    {
        var gameObject = Instantiate(_template, _parent, false);
        gameObject.SetActive( false );
        var poolObject = gameObject.GetComponent<PoolObject>();
        if(poolObject == null)
            poolObject = gameObject.AddComponent<PoolObject>( );
        poolObject.Containter = this;
        
        return gameObject;
    }

    public void ReturnToPool(PoolObject poolObject)
    {
        _poolQueue.Enqueue( poolObject.gameObject );
    }
}
