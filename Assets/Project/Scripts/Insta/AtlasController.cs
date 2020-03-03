//using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class PostInfo
{
    public int id;
    public string thumbnail;
    public string standard;
    public int likes;
    public int comments;
    public string post_url;
    public string description;
    public string usernameFrom;
    public string postLink;

    public Texture2D StandartTexture;
}
[System.Serializable]
public class _atlas
{
    public Rect[] rect;
    public Material atlas;

    public List<Material> _CreatedMaterials = new List<Material>();
}


public class AtlasController : MonoBehaviour
{
    public _LoadType LoadType;
    public enum _LoadType
    {
        Resources,
        Internet,
        Cache
    }

    public _atlas[] Atlases = new _atlas[2];



    public delegate void successFindedAcc();
    public static successFindedAcc _successFinded;

    public delegate void failedFindAcc(string arg);
    public static failedFindAcc _failedAcc;

    #region Singleton
    public static AtlasController instance;
    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);


    }
    #endregion;

    public IEnumerator Init(root_posts data)
    {
        Debug.Log("Inited");

        Texture2D[] images = new Texture2D[data._p.Count];
        for (int i = 0; i < data._p.Count; i++)
        {
            images[i] = data._p[i].StandartTexture;
        }
        //posts = data._p;

        yield return StartCoroutine(Pack(Atlases[0], 1024, images));
        yield return StartCoroutine(Pack(Atlases[1], 4096, images));
        yield return StartCoroutine(CreateMaterials(Atlases[0]));
        yield return StartCoroutine(CreateMaterials(Atlases[1]));
       // UnloadTextures();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            //UnloadTextures();
            ClearMaterials();
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        }
    }

    void ClearMaterials()
    {
        foreach(_atlas atlas in Atlases)
        {
            for (int i = 0; i < atlas._CreatedMaterials.Count; i++)
            {
                atlas._CreatedMaterials[i] = null;
            }
            atlas.atlas = null;
            atlas._CreatedMaterials.Clear();
        }
    }

    public IEnumerator CreateMaterials(_atlas a)
    {
        a._CreatedMaterials.Clear();

        foreach(Rect _rect in a.rect)
        {
            Material _mat = new Material(a.atlas);

            _mat.SetTextureScale("_MainTex", new Vector2(_rect.width, _rect.height));
            _mat.SetTextureOffset("_MainTex", new Vector2(_rect.x, _rect.y));

            a._CreatedMaterials.Add(_mat);
            yield return null;

        }
    }
    //returning offset by image id
    public Material GetMaterialById(_atlas a, int id)
    {
        return a._CreatedMaterials[id - 1];
    }
    

    public IEnumerator Pack(_atlas a, int size, Texture2D[] _textures)
    {
        Texture2D texture = new Texture2D(2,2);

        a.rect = texture.PackTextures(_textures, 5, size);
        a.atlas.SetTexture("_MainTex", texture);
        Debug.Log("Atlas width: " + a.atlas.mainTexture.width + "Atlas height: " + a.atlas.mainTexture.height);
        yield return null;
    }

    public void StopLoading()
    {
        StopAllCoroutines();    
    }

    //https://www.instagram.com/graphql/query/?query_id=17888483320059182&id=20021759479&first=20
}
//https://api.instagram.com/v1/users/self/follows?access_token=20021759479.9f7d92e.e4cf6803ec204e899ce887aab2b88cbf