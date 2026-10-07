using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class DownloadLeaderboardBehaviour : MonoBehaviour
{
    public string [] PlayersData;
    public List<string> PlayersName = new List<string>();
    public List<int> PlayersScore = new List<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            StartCoroutine(GetRequest("http://dreamlo.com/lb/6ac61ad78f40bb15a8d2a8d0/quote"));

        }

    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
            string pageContent = webRequest.downloadHandler.text;
            PlayersData = pageContent.Split('\n');
            for (int i = 0; i < PlayersData.Length; i++)
            {
                if (!string.IsNullOrEmpty(PlayersData[i]))
                {
                    string[] lineElements = PlayersData[i].Split(',');
                }
            }


        }
    }
}
