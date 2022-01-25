using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class TileMapManager : MonoBehaviour
{

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile tile; 

    private Vector3Int location; 
   
    private int tileMapHeight;

    private void Start() {

      tileMapHeight = tilemap.cellBounds.yMax*2;
      Debug.Log(tileMapHeight);
      MakeTowers();
      MakeTowers();
      MakeTowers();
    
    }

    void Update()
    {
      if(Input.GetMouseButtonDown(0)){
          Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          location = tilemap.WorldToCell(mousePosition);
          tilemap.SetTile(location, tile);
      }
    }

    void MakeTowers(){
      Vector3Int cellLocation = SelectRandomCellX(tilemap.cellBounds, tilemap.cellBounds.yMin);
    
      int gapHeight = Random.Range(4, 10);
      int gapLowerLimit = Random.Range(1,  tileMapHeight-gapHeight-1);
      int gapUpperLimit = gapLowerLimit+gapHeight;
      
      for (int i = 0; i <  tileMapHeight; i++)
      {
        if( i > gapLowerLimit && i <= gapUpperLimit)
          continue;
        location = cellLocation + new Vector3Int (0,i,0);
        tilemap.SetTile(location, tile);  
      }
    }

  
    Vector3Int SelectRandomCell(BoundsInt bounds){
      return SelectRandomCellX(bounds) + SelectRandomCellY(bounds);
    }

    Vector3Int SelectRandomCellX(BoundsInt bounds, int yCol = 0){
      return new Vector3Int(Random.Range(bounds.xMin, bounds.xMax),yCol,0);
    }

    Vector3Int SelectRandomCellY(BoundsInt bounds, int xRow = 0){
      return new Vector3Int(xRow,Random.Range(bounds.yMin, bounds.yMax),0);
    }
} 




