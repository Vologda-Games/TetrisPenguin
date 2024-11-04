using System;
using System.Globalization;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static void SetDateTime(string _key, DateTime _value)
    {
        string _convertdateToString = _value.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(_key, _convertdateToString);
    }

    public static DateTime GetDateTime(string _key, DateTime _value)
    {
        string _dateTimeFormatString = PlayerPrefs.GetString(_key);
        DateTime _result = DateTime.ParseExact(_dateTimeFormatString, "u", CultureInfo.InvariantCulture);
        return PlayerPrefs.HasKey(_key) ? _result : _value;
    }
}