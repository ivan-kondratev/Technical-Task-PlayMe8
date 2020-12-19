using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UserData", menuName = "User", order = 52)]
public class UserSO : ScriptableObject
{
    [Header("User Names")]
    [Space(15)]
    public string[] userNames;

    [Header("User Level Range")]
    [Space(15)]
    public int userLevelFrom;
    public int userLevelTo;

    [Header("User Avatars URL's")]
    public string[] urls;
}
