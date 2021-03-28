using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScreenUtils.Initialize();
        moveCameraEdges();
    }
    void moveCameraEdges(){
        Vector2 corner1 = new Vector2(ScreenUtils.ScreenLeft,ScreenUtils.ScreenTop);
        Vector2 corner2 = new Vector2(ScreenUtils.ScreenRight,ScreenUtils.ScreenTop);
        Vector2 corner3 = new Vector2(ScreenUtils.ScreenLeft,ScreenUtils.ScreenBottom);
        Vector2 corner4 = new Vector2(ScreenUtils.ScreenRight,ScreenUtils.ScreenBottom);
        Vector2[] pointsEdge1 =  new Vector2[2];
        pointsEdge1[0] = corner1;
        pointsEdge1[1] = corner2;
        Vector2[] pointsEdge2 =  new Vector2[2];
        pointsEdge2[0] = corner1;
        pointsEdge2[1] = corner3;
        Vector2[] pointsEdge3 =  new Vector2[2];
        pointsEdge3[0] = corner2;
        pointsEdge3[1] = corner4;
        EdgeCollider2D[] edgesCam = Camera.main.GetComponents<EdgeCollider2D>();
        edgesCam[0].points = pointsEdge1;
        edgesCam[1].points = pointsEdge2;
        edgesCam[2].points = pointsEdge3; 
    }
}
