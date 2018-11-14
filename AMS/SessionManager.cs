using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Diagnostics;

public static class SessionManager
{
    private static HttpSessionState MySession;

    public static void Initialize()
    {
        //If session is already initialized, return
        //Maikel
        if (MySession != null)
            return;

        MySession = HttpContext.Current.Session;
    }

    public static void LogIn(string username)
    {
        //Maikel
        Initialize();
        Username = username;
    }
    public static void LogInRole(int userrole)
    {
        //Enzo
        Initialize();
        UserRole = userrole;
    }  

    public static void LogOut()
    {
        //Maikel and Enzo
        Initialize();
        Username = null;
        UserRole = 0;
    }

    public static string Username
    {
        //Maikel
        get
        {
            if (MySession == null)
                return null;
            return (string)MySession["name"];
        }
        set
        {
            if (MySession == null)
                return;
            MySession["name"] = value;
        }

    }
    
    public static int UserRole
    {
        //Enzo
        get
        {
            if (MySession == null)
                return 0;
            return (int)MySession["role"];
        }
        set
        {
            if (MySession == null)
                return;
            MySession["role"] = value;
        }

    }

}