string startPath = @"c:\example\start";
string zipPath = @"c:\example\result.zip";

ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, true);
//только сборки и юзинги добавить
//System.IO.Compression;
//System.IO.Compression.FileSystem;