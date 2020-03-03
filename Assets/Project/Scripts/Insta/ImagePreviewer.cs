using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePreviewer : ui_basement
{
    public Image img;
    public RectTransform _ImgSize;
    public Text description;
    public Text username;
    public Text LikeCount;
    public string PostId;

    public override void Activate()
    {
        base.Activate();
    }

    public override void DeActivate()
    {
        base.DeActivate();
    }
    public void Preview(int id)
    {
        LoadPicture(id);
        setCommentField(id);
    }

    void LoadPicture(int id)
    {
        Sprite spr = DownloadManager.instance.GetImageById(id);
        img.sprite = spr;

        float sizeX = spr.rect.width / spr.rect.height;
        float sizeY = spr.rect.height / spr.rect.width;

        _ImgSize.sizeDelta *= new Vector2(sizeX, sizeY);
        if (_ImgSize.sizeDelta.x >= 900)
        {
            float diff = 900 / _ImgSize.sizeDelta.x;
            _ImgSize.sizeDelta *= new Vector2(diff, diff * 1.5f);
            _ImgSize.transform.localPosition = new Vector2(_ImgSize.transform.localPosition.x + 50f, _ImgSize.transform.localPosition.y);
        }
        else if (_ImgSize.sizeDelta.y >= 900)
        {
            float diff = 900 / _ImgSize.sizeDelta.y;
            _ImgSize.sizeDelta *= new Vector2(diff * sizeX * 1.5f, diff);
            _ImgSize.transform.localPosition = new Vector2(_ImgSize.transform.localPosition.x -50f, _ImgSize.transform.localPosition.y);
        }
    }

    public void CLose()
    {
        CanvasController.instance.CloseCanvas();
    }

    public void setDescriprion(int id)
    {
        Debug.Log(id);
        description.text = DownloadManager.instance._tempPosts._p[id-1].description;
    }

    public void setCommentField(int id)
    {
        description.text = DownloadManager.instance._tempPosts._p[id - 1].description;
        username.text = DownloadManager.instance._tempPosts._p[id - 1].usernameFrom;
        LikeCount.text = DownloadManager.instance._tempPosts._p[id - 1].likes.ToString() + " отметок \"нравится\"";
        PostId = DownloadManager.instance._tempPosts._p[id - 1].postLink;
    }

    private void OpenInInstagram()
    {
        string url = "https://www.instagram.com/p/" + PostId;
        Application.OpenURL(url);
    }
}