using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SocketIO;

using UnityEngine.UI;

public class Network : MonoBehaviour
{
    static SocketIOComponent socket;

    public Text getText;

    void Start()
    {
        socket = GetComponent<SocketIOComponent>();

        socket.On("open", OnConnected);

        socket.On("getValue", GetMessage);
        
    }

    private void OnConnected(SocketIOEvent obj)
    {
        Debug.Log("conected");
    }

    private void GetMessage(SocketIOEvent obj)
    {
        //string input = obj.data.ToString();
        //Debug.Log(input);

        JSONObject JSONobject = obj.data;

        getText.text = JSONobject["text"].ToString();

        Debug.Log(JSONobject["text"].ToString());
    }

    public void SendValue(int num)
    {
        JSONObject JSONobject = new JSONObject(JSONObject.Type.OBJECT);
        JSONobject.AddField("mynum",num);

        socket.Emit("Check", JSONobject);

        print("send value");
        
        //string data = JsonUtility.ToJson(num);
        //socket.Emit("Check", new JSONObject(data));

        
    }
}
