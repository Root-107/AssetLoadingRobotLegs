using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DB.Extensions.Downloading.IMP
{
    public class DownloadManager : MonoBehaviour
    {
        string zipExtention = ".zip";

        int assetsToDownload = 0;
        int assetsDownloaded = 0;
        Action downloadComplete;
        string writeLocation;
        string folder;
        public void Download(string[] urls, Action downloadComplete, string folder, string writeLocation) 
        {
            assetsToDownload = urls.Length;

            this.folder = folder;
            this.downloadComplete = downloadComplete;
            this.writeLocation = writeLocation;

            if (urls.Length == 0) 
            {
                downloadComplete?.Invoke();
                return;
            }

            for (int i = 0; i < assetsToDownload; i++)
            {
                string extention = Path.GetExtension(urls[i]);

                Action<LoadedAsset> callback = GetMethoud(extention);

                gameObject.AddComponent<Downloader>().Download(urls[i], callback);
            }
        }

        private void HandleDownloadComplete(LoadedAsset loadedData) 
        {
            if (loadedData != null)
            {
                if (!ByteArrayToFile($"{writeLocation}/{folder}/{loadedData.FileName}", loadedData.AssetBytes))
                {
                    Debug.Log($"Failed to write bytes to file: {loadedData.FileName}");
                }
            }

            UpdateCompleted();
        }

        private void HandleDownloadZip(LoadedAsset loadedData)
        {
            if (loadedData != null)
            {
                UnzipFromBytes(loadedData.AssetBytes, $"{writeLocation}/{folder}", ZipUnpacked);
            }
            else {
                UpdateCompleted();
            }
        }

        private void ZipUnpacked(bool success) 
        {
            if (!success)
            {
                Debug.LogError("Failed to unpack zip");
            }

            UpdateCompleted();
        }

        private void UpdateCompleted() 
        {
            assetsDownloaded++;
            Debug.Log($"Downloaded :{assetsDownloaded}/{assetsToDownload}");
            if (assetsDownloaded == assetsToDownload)
            {
                Debug.Log("All assets downloaded");
                //Remove the download manager for the scene
                StartCoroutine(Delaycallback());
            }
        }

        IEnumerator Delaycallback() 
        {
            yield return new WaitForSeconds(1);
            downloadComplete?.Invoke();
        }

        Action<LoadedAsset> GetMethoud(string extention) 
        {
            if (extention == zipExtention) 
            {
                return HandleDownloadZip;
            }
            return HandleDownloadComplete;
        }

        private bool ByteArrayToFile(string path, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

        private void UnzipFromBytes(byte[] zipBytes, string unzipToPath, Action<bool> completed = null)
        {
            try
            {
#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || UNITY_WSA_10_0)
                lzip.setEncoding(1);
#endif
                int[] progress = new int[1];
                int[] progress2 = new int[1];

                int zipResult = lzip.decompress_File(null, unzipToPath, progress, zipBytes, progress2);

                bool success = zipResult > 0;
                if (!success)
                {
                    Debug.Log("Zip failed to decompress");
                }

                if (completed != null) completed(success);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to unzip file from bytes ==> " + e.ToString());
                if (completed != null) completed(false);
            }
        }
    }
}
