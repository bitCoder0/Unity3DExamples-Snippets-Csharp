using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

///retrieves and parses the json array of objects from http://jsonplaceholder.typicode.com/posts

public class ParseJsonArrayOfObjects : MonoBehaviour {

    public readonly string server = "http://jsonplaceholder.typicode.com/posts";

   
    void Start () {
        StartCoroutine (GetData());
    }

    private void parseJson (string jsonString) {

        dataForm hey = JsonUtility.FromJson<dataForm> ("{\"data\":" + jsonString + "}");

        //now data is usable in our project        

        Debug.Log ("Retrieved "+hey.data.Length+" Recourds successfuly!");


        Debug.Log ("first post title:\n"+hey.data[0].title.ToString ());
    }

    IEnumerator GetData () {
        UnityWebRequest www = UnityWebRequest.Get (server);
        yield return www.SendWebRequest ();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log ("Error in retrieving data:" + www.error);
        } else {

            Debug.Log ("Successfully retrieved data from server:\n" + www.downloadHandler.text);

            parseJson (www.downloadHandler.text);

        }
    }

    /*
    sample data:
 [
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
  },
  (and more...)
  ]
     */
//data model:
	 
    [Serializable]
    public class UserObject {
        public int userId;
        public int id;
        public string title;
        public string body;
    }

    [Serializable]
    public class dataForm {
        public UserObject[] data;
    }

}