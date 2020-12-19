using UnityEngine;
using System;

namespace Assets.Scripts.Dowload_From_Server
{
    public class JsonHelper
    {
        public static T[] GetArray<T>(string json)
        {
            string newJson = "{\"data\":" + json + "}";
            Wrapper<T> w = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return w.data;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] data;
        }
    }
}
