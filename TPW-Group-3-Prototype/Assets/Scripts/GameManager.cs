using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject platObj;
    public List<GameObject> platforms;
    public List<GameObject> numberplatforms;
    public GameObject dude;
    int[] canthelp = new int[] {1,5,1,0,4,3,2,0,6,7,1,2,3,2,1};
    string[] canthelpWords = new string[] { "wise", "men", "say", "", "fools", "rush", "in", "", "I", "can't", "help", "falling", "love", "with", "you" };
    float[] xNotes = new float[8];
    public GameObject[] numbers = new GameObject[8];
    int currPlatform = 0;
    GameObject[] rHand;
    GameObject[] lHand;

    // Start is called before the first frame update
    void Start()
    {


        //int counterdebug = 0;
        platforms = new List<GameObject>();
        for (int i = 0; i < 8; i++) {
            xNotes[i] = -4.75f + (1.5f * i);
        }
        for(int j = 0; j < canthelp.Length; j++)
        {
            if(canthelp[j] > 0)
            {
                GameObject word = Instantiate(platObj, new Vector3(xNotes[canthelp[j]], 8 + (2.0f * j), 0), Quaternion.identity);
                word.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = canthelpWords[j];
                platforms.Add(word);

                numberplatforms.Add(Instantiate(numbers[canthelp[j]], new Vector3(-5.0f, 8 + (2.0f * j), 0), Quaternion.identity));
            }
            
            //Debug.Log(counterdebug);
            //counterdebug++;
        }
        rHand = GameObject.FindGameObjectsWithTag("Right");
        lHand = GameObject.FindGameObjectsWithTag("Left");
    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < platforms.Count; i++)
        {
            moveDown(platforms[i]);
        }

        for (int i = 0; i < numberplatforms.Count; i++)
        {
            moveDown(numberplatforms[i]);
        }

        if (dude.transform.position.y > -4.4)
        {
            moveDown(dude);
        }

        if (Input.GetKeyDown("space"))
        {
            if(platforms[currPlatform].transform.position.y < -1.5)
            {
                dude.transform.position = new Vector3(platforms[currPlatform].transform.position.x, platforms[currPlatform].transform.position.y + 0.5f, platforms[currPlatform].transform.position.z);
                platforms[currPlatform].transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "";
                currPlatform++;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TPW Game");
        }
       // if(rHand.Length == 0)
        //{
          //  rHand = GameObject.FindGameObjectsWithTag("Right");
            //lHand = GameObject.FindGameObjectsWithTag("Left");
        //}
        //else
        //{
          //  Debug.Log(rHand[0].transform.position.x);
        //}
        
    }

    private void moveDown(GameObject go)
    {
        float translation = Time.deltaTime * 1.15f;
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - translation, go.transform.position.z);
    }
}
