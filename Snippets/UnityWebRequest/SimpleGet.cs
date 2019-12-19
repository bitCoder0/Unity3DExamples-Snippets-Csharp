using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

///A Simple GET request to retrieve the text from a server

public class SimpleGet : MonoBehaviour {

    public string server = "http://jsonplaceholder.typicode.com/posts";

    void Start () {
        StartCoroutine (GetText ());
    }

    IEnumerator GetText () {
        UnityWebRequest www = UnityWebRequest.Get (server);
        yield return www.SendWebRequest ();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log ("Error in retrieving data:\n" + www.error);
        } else {
            // Show results as text
            Debug.Log ("Successfully retrieved data from server:\n" + www.downloadHandler.text);

            // Or retrieve results as binary data
           // byte[] results = www.downloadHandler.data;
        }
    }
}
