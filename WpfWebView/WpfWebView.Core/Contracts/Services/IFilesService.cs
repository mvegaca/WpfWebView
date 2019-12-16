﻿namespace WpfWebView.Core.Contracts.Services
{
    public interface IFilesService
    {
        T Read<T>(string folderPath, string fileName);

        void Save<T>(string folderPath, string fileName, T content);

        void Delete(string folderPath, string fileName);
    }
}
