using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class root_posts
{
    public string AccountKey;
    public List<PostInfo> _p = new List<PostInfo>();
}

public class DataSave : MonoBehaviour
{

    public static void SavePostsInfo(root_posts data)
    {
        for (int i = 0; i < data._p.Count; i++)
        {

            SaveImage(data._p[i].StandartTexture, "s_" + i, Application.persistentDataPath + "/images/standart/");
        }

        string str = JsonUtility.ToJson(data,true);

        File.WriteAllText(Application.persistentDataPath + "/posts.json", str);
    }

   
    public static root_posts GetpostsData()
    {
        root_posts root = new root_posts();
        string filepath = Application.persistentDataPath + "/posts.json";

        if (File.Exists(filepath))
        {
            string dataAsJson = File.ReadAllText(filepath);
            root = JsonUtility.FromJson<root_posts>(dataAsJson);
            return root;
        }
        else
        {
            return null;
        }
    }
    public static void SaveImage(Texture2D texture, string name, string filepath)
    {
        var bytes = texture.EncodeToPNG();

        CheckDirectory(filepath);

        var file = File.Open(Path.Combine(filepath, name + ".png"), FileMode.Create, FileAccess.ReadWrite);

        BinaryWriter writer = new BinaryWriter(file);
        writer.Write(bytes);

        writer.Close();
    }

    public static void SaveImage(Texture2D texture, string name, string filepath, bool overwrite)
    {
        if (overwrite)
        {
            if (File.Exists(Path.Combine(filepath, name + ".png")))
            {
                File.Delete(Path.Combine(filepath, name + ".png"));
            }

            var bytes = texture.EncodeToPNG();

            CheckDirectory(filepath);

            var file = File.Open(Path.Combine(filepath, name + ".png"), FileMode.Create, FileAccess.ReadWrite);

            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(bytes);

            writer.Close();
        }
    }

    static void CheckDirectory(string dir)
    {
        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    public static bool IsSaveExists()
    {
        if(File.Exists(Application.persistentDataPath + "/grid.json"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
