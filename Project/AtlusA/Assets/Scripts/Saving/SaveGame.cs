using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    private nn.account.Uid userId;
    private const string mountName = "MySave";
    private const string fileName = "MySaveData";
    private static readonly string filePath = string.Format("{0}:/{1}", mountName, fileName);
    private nn.fs.FileHandle fileHandle = new nn.fs.FileHandle();

    private nn.hid.NpadState npadState;
    private nn.hid.NpadId[] npadIds = { nn.hid.NpadId.Handheld, nn.hid.NpadId.No1 };
    private const int saveDataVersion = 1;
    private const int saveDataSize = 8;
    private int counter = 0;
    private int saveData = 0;
    private int loadData = 0;

    private void Start()
    {
#if UNITY_SWITCH && !UNITY_EDITOR
        nn.account.Account.Initialize();
        nn.account.UserHandle userHandle = new nn.account.UserHandle();

        if (!nn.account.Account.TryOpenPreselectedUser(ref userHandle))
        {
            nn.Nn.Abort("Failed to open preselected user.");
        }
        nn.Result result = nn.account.Account.GetUserId(ref userId, userHandle);
        result.abortUnlessSuccess();
        result = nn.fs.SaveData.Mount(mountName, userId);
        result.abortUnlessSuccess();

        InitSave();

        nn.hid.Npad.Initialize();
        nn.hid.Npad.SetSupportedStyleSet(nn.hid.NpadStyle.Handheld | nn.hid.NpadStyle.JoyDual);
        nn.hid.Npad.SetSupportedIdType(npadIds);
        npadState = new nn.hid.NpadState();
#endif
    }
#if UNITY_SWITCH && !UNITY_EDITOR
    private void InitSave()
    {
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (result.IsSuccess())
        {
            return;
        }
        if (!nn.fs.FileSystem.ResultPathNotFound.Includes(result))
        {
            result.abortUnlessSuccess();
        }

        byte[] data;
        using (BinaryWriter writer = new BinaryWriter(new MemoryStream(saveDataSize)))
        {
            writer.Write(saveDataVersion);
            writer.Write(counter);

            writer.BaseStream.Close();
            data = (writer.BaseStream as MemoryStream).GetBuffer();
            Debug.Assert(data.Length == saveDataSize);
        }

        result = nn.fs.File.Create(filePath, saveDataSize);
        result.abortUnlessSuccess();

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write);
        result.abortUnlessSuccess();

        const int offset = 0;
        result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);
        result = nn.fs.FileSystem.Commit(mountName);
        result.abortUnlessSuccess();
    }

    private void SaveCounter()
    {
        byte[] data;
        using (BinaryWriter writer = new BinaryWriter(new MemoryStream(sizeof(int))))
        {
            writer.Write(counter);

            writer.BaseStream.Close();
            data = (writer.BaseStream as MemoryStream).GetBuffer();
            Debug.Assert(data.Length == sizeof(int));
        }

        nn.Result result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write);
        result.abortUnlessSuccess();

        const int offset = 4;
        result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);
        result = nn.fs.FileSystem.Commit(mountName);
        result.abortUnlessSuccess();
    }
#endif

    private void Update()
    {
#if UNITY_EDITOR || !UNITY_SWITCH
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hello");
        }
#else
        if (Input.GetButtonDown("SaveTemp"))
        {
            Debug.Log("hello");
        }
#endif

    }
}
