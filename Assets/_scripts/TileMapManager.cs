using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile tile; 

    [SerializeField] private int minGap = 4;
    [SerializeField] private int maxGap = 10;
    [SerializeField] private int towerWidth = 2;

    [SerializeField] private int startingOffset = 3;
    [SerializeField] private int minTowerSpacing = 3;
    [SerializeField] private int maxTowerSpacing = 7;
    
    private int previousTowerX; 
    private Vector3Int towerLocation = Vector3Int.zero;
    private Vector3Int location; 
    private int tileMapHeight;

    private void Start() {
      tileMapHeight = tilemap.size.y;
      previousTowerX = tilemap.origin.x + startingOffset;
      towerLocation = new Vector3Int(0, tilemap.origin.y ,0 );
      int xMaxLimint = tilemap.size.x + tilemap.origin.x - towerWidth;
      
            
      for(int p = previousTowerX; p < xMaxLimint; p = getNextTowerX())
      { 
        towerLocation.x = p;
        MakeTower(towerLocation, towerWidth);
        previousTowerX = p+towerWidth;
      }
    }


    int getNextTowerX(){
      return  previousTowerX + Random.Range(minTowerSpacing, maxTowerSpacing+1);
    }

    void MakeTower(Vector3Int origin, int width){
      int gapHeight = Random.Range(minGap, maxGap);
      int gapLowerLimit = Random.Range(1,  tileMapHeight-gapHeight-1);
      int gapUpperLimit = gapLowerLimit+gapHeight;
      for (int c = 0; c <=  width; c++)
      {
          for (int i = 0; i <  tileMapHeight; i++)
          {
            Debug.Log("Running: " + tileMapHeight);
            if( i > gapLowerLimit && i <= gapUpperLimit)
              continue;
            location = origin + new Vector3Int (c,i,0);
            tilemap.SetTile(location, tile);  
          }
      }
    }


    //Todo 
    //determine cells before caling set tile
    //add colliders at the end instead of each step.
 
} 
