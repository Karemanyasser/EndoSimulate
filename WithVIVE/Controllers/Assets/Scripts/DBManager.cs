using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{
   public static string UserID;

   public static string FirstName;
   public static string LastName;
   public static int score;

   public static bool LoggedIn { get 
        { return UserID != null; }
   }

   public static void LogOut() { 
        UserID = null;
   }

}
