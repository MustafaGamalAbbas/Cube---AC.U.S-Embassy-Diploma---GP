using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public enum GetWayDirection
    {
        Xplus, Xneg, Yplus, Yneg, Zplus, Zneg
    }
    public enum DoorEdge
    {
       Right, Left
    }
  
    public static List<string> cubeThemeMates = new List<string>() {"blue",  "cyan" , "green" , "purple" ,"red" , "terquaz", "yellow" };

    private string[] primeNumbers = { "02", "03", "05", "07", "11", "13", "17", "19", "23", "29", "31", "37",
                                      "41", "43", "47", "53", "59", "61", "67", "71", "73", "79", "83", "89", "97" };
}
