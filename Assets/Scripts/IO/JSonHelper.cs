﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menchestan
{
    namespace IO
    {
        public static class JsonHelper
        {
            public static List<T> FromJson<T>(string json)
            {
                json = FixJson(json);
                Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
                return wrapper.Items;
            }
            static string FixJson(string value)
            {
                value = "{\"Items\":" + value + "}";
                return value;
            }
            public static string ToJson<T>(List<T> array)
            {
                Wrapper<T> wrapper = new Wrapper<T>();
                wrapper.Items = array;
                return JsonUtility.ToJson(wrapper);
            }

            public static string ToJson<T>(List<T> array, bool prettyPrint)
            {
                Wrapper<T> wrapper = new Wrapper<T>();
                wrapper.Items = array;
                return JsonUtility.ToJson(wrapper, prettyPrint);
            }

            [Serializable]
            private class Wrapper<T>
            {
                public List<T> Items;
            }
        }
    }
}