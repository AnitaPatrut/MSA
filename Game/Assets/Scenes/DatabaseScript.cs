using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DatabaseScript : MonoBehaviour
{
    public GameObject inputField_user;
    public GameObject inputField_pass;
    public GameObject textDisplay;
    // Start is called before the first frame update
    IEnumerator LoginDB(string username, string password)
    {
        //WWW itemsData = new WWW("http://localhost/Users/ItemsData.php");
        //yield return itemsData;
        //string items = itemsData.text;
        //print(items);
        
        string[] items;
        WWWForm itemsData = new WWWForm();
        string user;
        string pass;
        bool flag = false;

        using(UnityWebRequest www = UnityWebRequest.Get("http://localhost/Users/ItemsData.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string itemsDataString = www.downloadHandler.text;
                items = itemsDataString.Split(';');
                print(itemsDataString);
                for(int i=0; i<itemsDataString.Length - 1; i++)
                {
                    
                    user = items[i].Substring(items[i].IndexOf("Username:") + "Username:".Length);
                    user = user.Remove(user.IndexOf("|"));
                    
                    pass = items[i].Substring(items[i].IndexOf("Password:") + "Password:".Length);
                    pass = pass.Remove(pass.IndexOf("|"));


                    if(user == username && pass == password)
                    {
                        textDisplay.GetComponent<Text>().text = "Logged in successfully.";
                        flag = true;
                        break;
                    }
                }
                if(flag == false)
                    textDisplay.GetComponent<Text>().text = "Invalid username or password.";
            }
        }
    }

    IEnumerator RegisterDB(string username, string password)
    {
        string res;
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        using(UnityWebRequest www = UnityWebRequest.Post("http://localhost/Users/InsertData.php", form))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                res = www.downloadHandler.text;
                textDisplay.GetComponent<Text>().text = res;
            }
        }
    }

    public void RegisterFunction()
    {
        string username;
        string password;

        username = inputField_user.GetComponent<Text>().text;
        password = inputField_pass.GetComponent<Text>().text;

        //Debug.Log(username);
        //textDisplay.GetComponent<Text>().text = username;
        StartCoroutine(RegisterDB(username, password));
    }

    public void LoginFunction()
    {
        string username;
        string password;

        username = inputField_user.GetComponent<Text>().text;
        password = inputField_pass.GetComponent<Text>().text;

        //Debug.Log(username);
        //textDisplay.GetComponent<Text>().text = username;
        StartCoroutine(LoginDB(username, password));
    }
}
