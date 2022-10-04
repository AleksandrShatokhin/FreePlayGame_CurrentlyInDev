using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBaseInformation
{
    public static string userName;
    public static int score;

    public static bool LoggedIn { get { return userName != null; } }

    public static void LogOut() => userName = null;
}
