using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
#if UNITY_SWITCH
    private void Load()
    {
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (nn.fs.FileSystem.ResultPathNotFound.Includes(result))
        {
            return;
        }
        result.abortUnlessSuccess();

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Read);
        result.abortUnlessSuccess();

        long fileSize = 0;
        result = nn.fs.File.GetSize(ref fileSize, fileHandle);
        result.abortUnlessSuccess();

        byte[] data = new byte[fileSize];
        result = nn.fs.File.Read(fileHandle, 0, data, fileSize);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);

        using (BinaryReader reader = new BinaryReader(new MemoryStream(data)))
        {
            int version = reader.ReadInt32();
            Debug.Assert(version == saveDataVersion); // Save data version up
            counter = reader.ReadInt32();
        }
    }

    private void ResetData()
    {
        counter = 0;
        SaveCounter();
        saveData = counter;
#endif
}
