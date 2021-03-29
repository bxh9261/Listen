using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class GameManager : MonoBehaviour
{
    public GameObject platObjMaj;
    public GameObject platObjMin;
    GameObject marb;
    public List<GameObject> platforms;
    List<int> randomNotes;
    float[] xNotes = new float[8];
    int currPlatform = 0;
    public List<AudioSource> audioDataMajor;
    public List<AudioSource> audioDataMinor;
    bool isMajor;
    string value = "0";
    int intValue = 0;

    int randomIndex = 0;

    public float Timer = 2f;

    SerialPort stream = new SerialPort("COM8", 9600);

    // Start is called before the first frame update
    void Start()
    {
        stream.Open();

        isMajor = true;

        randomNotes = new List<int>();

        for (int i = 0; i < 100; i++)
        {
            randomNotes.Add(Random.Range(0, 8));
        }

        //int counterdebug = 0;
        platforms = new List<GameObject>();
        for (int i = 0; i < 8; i++) {
            xNotes[i] = -4.75f + (1.5f * i);
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < platforms.Count; i++)
        {
            moveDown(platforms[i]);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TPW Game");
        }

        for (int i = 0; i < 100; i++)
        {
            
            value = stream.ReadLine();
            if(value == "M")
            {
                isMajor = !isMajor;
            }
            else
            {
                intValue = 0;
                int.TryParse(value, out intValue);
            }
        }

        Debug.Log("int=" + intValue);

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            if (isMajor)
            {
                marb = Instantiate(platObjMaj, new Vector3(xNotes[randomNotes[randomIndex]], -1, 0), Quaternion.identity);
            }
            else
            {
                marb = Instantiate(platObjMin, new Vector3(xNotes[randomNotes[randomIndex]], -1, 0), Quaternion.identity);
            }
            platforms.Add(marb);
            if (intValue == 0)
            {
                Timer = 2f;
            }
            else
            {
                Timer = 1.5f/(intValue*1.5f);
                
            }
            
            randomIndex++;
            if(randomIndex > 99)
            {
                randomIndex = 0;
            }
            
        }

    }

    private void moveDown(GameObject go)
    {
        
        float translation = (Time.deltaTime * 10.0f);
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - translation, go.transform.position.z);

        if (go.transform.position.y < -5)
        {
            playNoteFor(go);
            platforms.Remove(go);
            Destroy(go);
        }
    }

    private void playNoteFor(GameObject go)
    {
        for(int i = 0; i < xNotes.Length; i++)
        {
            if (go.transform.position.x == xNotes[i])
            {
                if (isMajor)
                {
                    audioDataMajor[i].Play(0);
                }
                else
                {
                    audioDataMinor[i].Play(0);
                }
                
            }
        }
    }
}
