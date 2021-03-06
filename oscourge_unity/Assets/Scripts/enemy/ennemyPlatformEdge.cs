﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ennemyPlatformEdge : MonoBehaviour
{

    public Tilemap tilemap;
    public float speed;
    public GameObject gameManager;


    Vector3Int pos;

    Vector3 pos2;

    int direction;

    float width;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        width = GetComponent<BoxCollider2D>().bounds.size.x;
        height = GetComponent<BoxCollider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {

        pos2 = transform.position;

        switch (direction)
        {
            case 0:
                transform.localScale = new Vector3(-1f, 1f, 1f);
                pos.x = (int)(pos2.x - (width / 2));
                pos.y = (int)pos2.y - 1;
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(speed / 100, 0, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 1:

                transform.localEulerAngles = new Vector3(0, 0, 270);
                pos.x = (int)(pos2.x -1);
                pos.y = (int)(pos2.y-(height/2) -1);
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(0, -speed / 100, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 2:
                pos.x = (int)(pos2.x - 1);
                pos.y = (int)(pos2.y -( height / 2 ));
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(0, -speed / 100, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 3:
                pos.x = (int)(pos2.x - 1);
                pos.y = (int)(pos2.y+(height/2));
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(0, -speed / 100, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 4:

                transform.localEulerAngles = new Vector3(0, 0, 180);
                pos.x = (int)(pos2.x - (width/2)-1);
                pos.y = (int)(pos2.y+1);
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(-speed/100, 0, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 5:
                pos.x = (int)(pos2.x+(width/2));
                pos.y = (int)(pos2.y + 1);
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(-speed / 100, 0, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 6:
                transform.localEulerAngles = new Vector3(0, 0, 90);
                pos.x = (int)(pos2.x + 1);
                pos.y = (int)(pos2.y + 1);
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(0, speed / 100    , 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 7:
                pos.x = (int)(pos2.x + 1);
                pos.y = (int)(pos2.y );
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(0, speed / 100, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 8:
                pos.x = (int)(pos2.x + 1);
                pos.y = (int)(pos2.y-(height/2));
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(0, speed / 100, 0);
                }
                else
                {
                    direction++;
                }
                break;
            case 9:
                transform.localScale = new Vector3(-1f, 1f, 1f);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                pos.x = (int)(pos2.x + 1);
                pos.y = (int)pos2.y - 1;
                pos.z = 0;

                if (tilemap.GetTile(pos) != null)
                {
                    transform.position = transform.position + new Vector3(speed / 100, 0, 0);
                }
                else
                {
                    direction=0;
                }
                break;
    
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
