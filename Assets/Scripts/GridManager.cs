using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public GameObject[] prefabs;
    public char[] map;
    public int width;
    public float scale;
    public Transform parent;

    private enum TERRAIN
    {
        REGULAR = 'R',
        ELEMENT = 'E',
        TRAP = 'T'
    }

	// Use this for initialization
	void Start () {
        map = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R',
                           'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R',
                           'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R',
                           'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R',
                           'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R',
                           'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R'};
        width = 8;
        scale = 5.0f;
        CreateGrid(map, width, scale);
    }

    void CreateGrid(char[] map, int width, float scale)
    {
        int height = map.Length / width;
        float sizeX = prefabs[0].GetComponent<SpriteRenderer>().size.x * scale;
        float sizeY = prefabs[0].GetComponent<SpriteRenderer>().size.y * scale;
        float actualX;
        float actualY = 0.0f;
        bool flip;
        for (int i = 0; i < height; i++)
        {
            actualX = 0.0f;
            flip = (i % 2 == 0) ? true : false;
            for(int j = 0; j < width; j++)
            {
                GameObject go = null;
                switch ((TERRAIN)map[i*width + j])
                {
                    case TERRAIN.REGULAR:
                        if (flip)
                        {
                            go = Instantiate(prefabs[10], new Vector3(actualX, actualY, 0.0f), Quaternion.identity);
                        }
                        else
                        {
                            go = Instantiate(prefabs[11], new Vector3(actualX, actualY, 0.0f), Quaternion.identity);
                        }
                        break;
                    case TERRAIN.ELEMENT:
                        go = Instantiate(prefabs[0], new Vector3(actualX, actualY, 0.0f), Quaternion.identity);
                        break;
                }
                if (go)
                {
                    go.transform.localScale = new Vector3(scale, scale, 1.0f);
                }
                flip = !flip;
                actualX += sizeX;
            }
            actualY += sizeY;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
