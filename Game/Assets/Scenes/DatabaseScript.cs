using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/Users/ItemsData.php");
        yield return itemsData;
        string items = itemsData.text;
        print(items);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
