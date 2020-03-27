using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OpenStorage : MonoBehaviour
{
	private List<Sprite> sprites = new List<Sprite>();
	private int i = 0;
	private int selectedPhotos = 0;

	public GameObject[] testImages;

    void PickImages(int maxSize)
    {
		NativeGallery.Permission permission = NativeGallery.GetImagesFromGallery((paths) =>
		{
			if (paths != null)
			{
				foreach (string path in paths)
				{
					for (i = 0; i < paths.Length; i++)
					{
						Texture2D texture = NativeGallery.LoadImageAtPath(paths[i], maxSize, true, false, false);
						sprites.Add(Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f, 1, SpriteMeshType.FullRect));
					}
					selectedPhotos++;
				}
				if (paths.Length == 4)
				{
					Debug.Log("selected: " + selectedPhotos);
				}
				else if (paths.Length < 4 || paths.Length > 4)
				{
					Debug.Log("selected: " + selectedPhotos);
					return;
				}
				testImages[0].GetComponent<Image>().sprite = sprites[0];
                testImages[1].GetComponent<Image>().sprite = sprites[1];
                testImages[2].GetComponent<Image>().sprite = sprites[2];
                testImages[3].GetComponent<Image>().sprite = sprites[3];
				Debug.Log("photos: " + paths.Length);
			}
		});
		//, title: "Select a PNG image",mime: "image/png"
	}

	public void OnClick()
    {
		PickImages(1024);
	}
}
