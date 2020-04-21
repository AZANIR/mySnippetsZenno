

/*
http://zennolab.com/discussion/threads/automatically-creating-loading-files-and-folders-structure-at-project-start.19364/

Someone is already selling projects, someone is just going to start selling and someone needs to create portable projects, which can be easily transfered from one computer to another.

Projects usually process some data, and it is necessary to distribute them with the projects. You can do it in the following way: create archive with data structure, upload it to the server, so that the archive could be accessed by Http protocol. Then, in your project, you should check if the directory with the archive file exists, download and unpack the archive.

Here are the examples of two C# snippets, which will help you to do it:

*/

//PACK

lock(SyncObject)
{
    // creating function for compressing files
    Action<string, string, System.IO.Compression.GZipStream> compressFile = (sDir, sRelativePath, zipStream) =>
    {
        //writing file name
        var chars = sRelativePath.ToCharArray();
        zipStream.Write(BitConverter.GetBytes(chars.Length), 0, sizeof(int));
        foreach (var c in chars)
            zipStream.Write(BitConverter.GetBytes(c), 0, sizeof(char));
 
        //Compress file content
        var bytes = System.IO.File.ReadAllBytes(System.IO.Path.Combine(sDir, sRelativePath));
        zipStream.Write(BitConverter.GetBytes(bytes.Length), 0, sizeof(int));
        zipStream.Write(bytes, 0, bytes.Length);
    };
     
    // Variable dirToPack should contain files of your project
    var sInDir = project.Variables["dirToPack"].Value;
    // Variable packedFile should contain the path to archive file
    var sOutFile = project.Variables["packedFile"].Value;
 
    var sFiles = System.IO.Directory.GetFiles(sInDir, "*.*", System.IO.SearchOption.AllDirectories);
    var iDirLen = sInDir[sInDir.Length - 1] == System.IO.Path.DirectorySeparatorChar ? sInDir.Length : sInDir.Length + 1;
    // packing all files from directory to one file
    using (var outFile = new System.IO.FileStream(sOutFile, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
    using (var str = new System.IO.Compression.GZipStream(outFile, System.IO.Compression.CompressionMode.Compress))
        foreach (var sFilePath in sFiles)
        {
            var sRelativePath = sFilePath.Substring(iDirLen);
            compressFile(sInDir, sRelativePath, str);
        }
}


//UNPACK

lock(SyncObject)
{
    // variable dirToUnpack should contain path to project directory with data
    var destDir = project.Variables["dirToUnpack"].Value;
    // Url-address for downloading file with settings
    var packedFile = project.Variables["packedFile"].Value;
    // return if directory with data already created
    if (System.IO.Directory.Exists(destDir)) return "ok";
    // if no then download file and create data structure
    var file = ZennoPoster.HttpGet(packedFile, respType: ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.File);
    // create a function to decompress
    Func<string, System.IO.Compression.GZipStream, bool> deCompressFile = (sDir, zipStream) =>
    {
        //Decompress file name
        var bytes = new byte[sizeof(int)];
        var readed = zipStream.Read(bytes, 0, sizeof(int));
        if (readed < sizeof(int))
            return false;
 
        var iNameLen = BitConverter.ToInt32(bytes, 0);
        bytes = new byte[sizeof(char)];
        var sb = new System.Text.StringBuilder();
        for (var i = 0; i < iNameLen; i++)
        {
            zipStream.Read(bytes, 0, sizeof(char));
            var c = BitConverter.ToChar(bytes, 0);
            sb.Append(c);
        }
        var sFileName = sb.ToString();
 
 
        //Decompress file content
        bytes = new byte[sizeof(int)];
        zipStream.Read(bytes, 0, sizeof(int));
        var iFileLen = BitConverter.ToInt32(bytes, 0);
 
        bytes = new byte[iFileLen];
        zipStream.Read(bytes, 0, bytes.Length);
 
        string sFilePath = System.IO.Path.Combine(sDir, sFileName);
        string sFinalDir = System.IO.Path.GetDirectoryName(sFilePath);
        if (!System.IO.Directory.Exists(sFinalDir))
            System.IO.Directory.CreateDirectory(sFinalDir);
 
        using (var outFile = new System.IO.FileStream(sFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
            outFile.Write(bytes, 0, iFileLen);
 
        return true;
    };
    // uncompressing downloaded file
    using (var inFile = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
    {
        using (var zipStream1 = new System.IO.Compression.GZipStream(inFile, System.IO.Compression.CompressionMode.Decompress, true))
        {
            while (deCompressFile(destDir, zipStream1))
            {
            }
        }
    }
    // deleting downloaded archive
    System.IO.File.Delete(file);
}