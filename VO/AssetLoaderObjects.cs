using System;
using System.Collections.Generic;
using UnityEngine;

public enum AssetTypes
{
    Image,
    Video,
    Text,
    PDF,
    Texture
}

public class RequestedAsset
{
    public int id;
    public string title;
    public AssetTypes type;
    public string value;
    public Sprite sprite;
    public List<Sprite> pdf;
    public Texture2D texture;
    public object payload;

    public RequestedAsset(int id, string title, AssetTypes type, string value = null, Sprite img = null, List<Sprite> images = null, Texture2D texture = null, object payload = null)
    {
        this.id = id;
        this.title = title;
        this.type = type;
        this.value = value;
        this.sprite = img;
        this.pdf = images;
        this.texture = texture;
        this.payload = payload;
    }
}

[Serializable]
public class Asset
{
    public int id;
    public string filePath;
    public string title;
    public AssetTypes assetType;
    public int pages;
    public object payload;

    public Asset(int _id, string filePath, string title, AssetTypes type, int pages = 0)
    {
        this.id = _id;
        this.filePath = filePath;
        this.title = title;
        this.assetType = type;
        this.pages = pages;
    }
}

[Serializable]
public class Assets
{
    public Asset[] assets;
}

public class LoadedAsset
{
    public string FileName { get; private set; }
    public byte[] AssetBytes { get; private set; }

    public LoadedAsset(string fileName, byte[] bytes)
    {
        FileName = fileName;
        AssetBytes = bytes;
    }
}

[Serializable]
public class AssetAPIData
{
    public string dbName;
    public UpdatedAssets[] updates;
    public URL[] zipData;
    public Assets complete;
    public string since;
}

[Serializable]
public class URL
{
    public string url;
}

[Serializable]
public class UpdatedAssets
{
    public int id;
    public string filePath;
}

[Serializable]
public class ServerAsset
{
    public string databaseName;
    public int id;
    public string title;
}