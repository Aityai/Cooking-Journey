using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Contact.Messages;

public class ShareValue {

    // Use this for initialization
    public static int intValue = 0;
    public static float floatValue = 0.0f;
    public static string stringValue = "";
    public static bool boolValue = false;

    public static Vector2 vector2Value = new Vector2(0.0f, 0.0f);
    public static Vector3 vector3Value = new Vector3(0.0f, 0.0f, 0.0f);

    public static MessageMaster masterValue = MessageMaster.none;
    public static MessageObject objectValue = MessageObject.none;
    public static MessageSystem systemValue = MessageSystem.none;

}

