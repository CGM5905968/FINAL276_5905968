using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SocketIO;

public class Network : MonoBehaviour
{
    static SocketIOComponent socket;



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

        Debug.Log(JSONobject["text"].ToString());
    }

    public void SendValue(int num)
    {
        JSONObject JSONobject = new JSONObject(JSONObject.Type.OBJECT);
        JSONobject.AddField("mynum",num);

        socket.Emit("Check", JSONobject);
        
        //string data = JsonUtility.ToJson(num);
        //socket.Emit("Check", new JSONObject(data));

        
    }
}
