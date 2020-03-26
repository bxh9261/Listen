using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject hands;
    public GameObject dude;
    int[] marks = new int[] {3,5,5,2,1,2,3,4,5,3,1};
    int currPlatform = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDown(hands);

        for(int i = 0; i < platforms.Length; i++)
        {
            moveDown(platforms[i]);
        }
        
        if(dude.transform.position.y > -4.4)
        {
            moveDown(dude);
        }

        if (Input.GetKeyDown("space"))
        {
            if(platforms[currPlatform].transform.position.y < -1.5)
            {
                dude.transform.position = new Vector3(platforms[currPlatform].transform.position.x, platforms[currPlatform].transform.position.y + 0.5f, platforms[currPlatform].transform.position.z);
                currPlatform++;
            }
        }
    }

    private void moveDown(GameObject go)
    {
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 0.01f, go.transform.position.z);
    }
}
