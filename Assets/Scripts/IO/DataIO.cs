using System;
using System.IO;
using System.Text;
using UnityEngine;
using Menchestan.Server;
using System.Runtime.Serialization.Formatters.Binary;

namespace Menchestan
{
    namespace IO
    {
        public static class DataIO
        {
            public static bool IsExist(string fileName)
            {
                return File.Exists(Application.persistentDataPath + "/" + fileName);
            }
            public static void ToJson<T>(string fileName, T data)
            {
                string destination = Application.persistentDataPath + "/" + fileName;
                File.WriteAllBytes(destination, Encoding.UTF8.GetBytes(JsonUtility.ToJson(data)));
            }
            public static T FromJson<T>(string fileName, bool asByte = false)
            {
                string destination = Application.persistentDataPath + "/" + fileName;
                if (File.Exists(destination))
                {
                    string data = "";
                    if (asByte)
                        data = Encoding.UTF8.GetString(File.ReadAllBytes(destination));
                    else
                        data = File.ReadAllText(destination, Encoding.UTF8);

                    return JsonUtility.FromJson<T>(data);
                }
                else
                {
                    DebugX.Error("File not found");
                    return default;
                }
            }

            public static void CacheUrl<T>(string url, Action<bool, T> callback)
            {
                if (!IsExist(url))
                {
                    ServerKit.Instance.GetFile<T>("/download" + url, (s, r, m, c) =>
                    {
                        if (s)
                        {
                            if (typeof(T) == typeof(Texture2D))
                                SaveTextureAsPNG((Texture2D)(object)r, url);
                            else if (typeof(T) == typeof(Sprite))
                                SaveTextureAsPNG(((Sprite)(object)r).texture, url);
                            callback?.Invoke(true, LoadPNG<T>(url));
                        }
                        else
                        {
                            callback?.Invoke(false, default);
                        }
                    }, null, true, false, true);
                }
                else
                {
                    callback?.Invoke(true, LoadPNG<T>(url));
                }
            }
            public static T LoadPNG<T>(string fileName)
            {
                Texture2D texture = null;
                byte[] fileData;
                if (IsExist(fileName))
                {
                    string fullPath = Application.persistentDataPath + "/" + fileName;
                    fileData = File.ReadAllBytes(fullPath);
                    texture = new Texture2D(2, 2);
                    texture.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                    if (typeof(T) == typeof(Texture2D))
                        return (T)(object)texture;
                    else if (typeof(T) == typeof(Sprite))
                        return (T)(object)Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                }
                return default;
            }
            public static void SaveTextureAsPNG(Texture2D texture, string fileName)
            {
                if (IsExist(fileName))
                    return;
                string fullPath = Application.persistentDataPath + "/" + fileName;

                string directory = Directory.GetParent(fullPath).FullName;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                byte[] bytes = texture.EncodeToPNG();
                File.WriteAllBytes(fullPath, bytes);
            }
            public static void SaveFile<T>(string fileName, T data)
            {
                string destination = Application.persistentDataPath + "/" + fileName;
                FileStream file;

                if (File.Exists(destination)) file = File.OpenWrite(destination);
                else file = File.Create(destination);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, data);
                file.Close();
            }
            public static T LoadFile<T>(string fileName)
            {
                string destination = Application.persistentDataPath + "/" + fileName;
                FileStream file;
                if (File.Exists(destination)) file = File.OpenRead(destination);
                else
                {
                    DebugX.Error("File not found");
                    return default;
                }
                BinaryFormatter bf = new BinaryFormatter();
                T data = (T)bf.Deserialize(file);
                file.Close();
                return data;
            }
        }
    }
}