using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDaFroot : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private Vector2 pos;
    public GameObject[] myGameObjectToRespawn;
    // Start is called before the first frame update
    void Start()
    {
        setMinAndMax();
        SpawnObj();
    }

    private void setMinAndMax()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        minX = -Bounds.x;
        maxX = Bounds.x;
        minY = -Bounds.y;
        maxY = Bounds.y;
    }
    // Update is called once per frame
    private void SpawnObj()
    {
        int NumberOfObj = Random.Range(0, myGameObjectToRespawn.Length);
        pos= new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject obj = Instantiate(myGameObjectToRespawn[NumberOfObj], pos, Quaternion.identity);
        obj.transform.parent = transform;
    }
    void Update()
    {
        
    }
}
