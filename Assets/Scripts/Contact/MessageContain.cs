using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Contact.Messages
{
    public sealed class MessageContain : MonoBehaviour
    {
        #region Singleton
        //
        static MessageContain _instance;
        public static MessageContain Intance
        {
            get
            {
                //if instance not exist, then create
                if (_instance == null)
                {
                    //create gameobject, and add interfaceMessage component
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<MessageContain>();
                    singletonObject.name = "Singleton-contact";
                    Common.Log("Create singleton : {0}", singletonObject.name);
                }
                return _instance;
            }
            private set { }
        }
        //
        void Awake()
        {
            //check another instance already exist in scence
            if (_instance != null && _instance.GetInstanceID() != this.GetInstanceID())
            {
                Common.Log("An instance of EventDispatcher already exist : <{1}>, " +
                            "So destroy this instance : <{2}>!!", _instance.name, name);
                Destroy(gameObject);
            }
        }
        //
        void OnDestroy()
        {
            // reset this static var to null if it's the singleton instance
            if (_instance == this)
                _instance = null;
        }
        #endregion
        //
        //
        #region Init, declare all store Listener dictionary
        //
        Dictionary<MessagePost, List<Action<Component, object>>> listener = new Dictionary<MessagePost, List<Action<Component, object>>>();
        #endregion
        //
        //
        #region Add listener object, post message, wait message
        //
        public void WaitMessage(MessagePost message, Action<Component, object> callback)
        {
            //checking parmas
            //checking if key exist in dictionary
            //only add dictionary when event not 0
            //
            if (message != MessagePost.none)
            {
                if (listener.ContainsKey(message))
                {
                    listener[message].Add(callback);
                }
                else
                {
                    var newListener = new List<Action<Component, object>>();
                    newListener.Add(callback);
                    listener.Add(message, newListener);
                }
            }
        }
        #endregion
        //
        //
        #region postMessage
        //
        public void PostMessage(MessagePost post, Component sender, object param = null)
        {
            //get action list from dictionary
            List<Action<Component, object>> waitList = new List<Action<Component, object>>();
            //
            if (post != MessagePost.none)
            {
                waitList.Clear();
                if (listener.TryGetValue(post, out waitList))
                {
                    for (int i = 0, amount = waitList.Count; i < amount; i++)
                    {
                        try
                        {
                            waitList[i](sender, param);
                        }
                        catch (Exception e)
                        {
                            //remove listeer at i - that cause the exception
                            //if no listener remain then declete this key
                            Common.LogWarning(this, "Error whenn PostEvent : {0}, message : {2}", post, e.Message);
                            waitList.RemoveAt(i);
                            if (0 == waitList.Count)
                            {
                                listener.Remove(post);
                            }
                            amount--;
                            i--;
                        }
                    }
                }
                else
                {
                    Common.LogWarning(this, "PostEvent, event : {0}, no listener for this event", post.ToString());
                }
            }
        }
        //
        #endregion
        //
        //

        public void UniTest()
        {
            Debug.Log(" It's so OK");
        }

    }
    //
    //
    #region  Extension class
    //declear some shortcut for using path method
    public static class InterfaceDispather
    {
        #region add message, viva data
        //use extenstion class to register
        public static void MessageWait(this MonoBehaviour sender, MessagePost messagePost, Action<Component, object> callback)
        {
            MessageContain.Intance.WaitMessage(messagePost, callback);
        }
        //
        //
        public static void MessagePost(this MonoBehaviour sender, MessagePost messagePost)
        {
            MessageContain.Intance.PostMessage(messagePost, sender, null);
        }

        //send and get value var
        //send value when post message
        public static void SendFloat(this MonoBehaviour sender, float send)
        {
            ShareValue.floatValue = send;
        }
        //
        public static void SendInt(this MonoBehaviour sender, int send)
        {
            ShareValue.intValue = send;
        }
        //
        public static void SendBool(this MonoBehaviour sender, bool send)
        {
            ShareValue.boolValue = send;
        }
        //
        public static void SendString(this MonoBehaviour sender, string send)
        {
            ShareValue.stringValue = send;
        }
        //
        public static void SendVector2(this MonoBehaviour sender, Vector2 send)
        {
            ShareValue.vector2Value = send;
        }
        //
        public static void SendVector3(this MonoBehaviour sender, Vector3 send)
        {
            ShareValue.vector3Value = send;
        }


        #endregion
        //
        //
        #region include action data
        //include action event

        #endregion
    }
    //
    #endregion
}
