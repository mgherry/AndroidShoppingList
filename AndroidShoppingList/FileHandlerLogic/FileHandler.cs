using Newtonsoft.Json;
using AndroidShoppingList.ScreenDisplays;
using AndroidShoppingList.UtilityClasses;
using Microsoft.Maui.Storage;
using System;
using System.Security.Principal;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace AndroidShoppingList.FileHandlerLogic
{
    public class FileHandler : Singleton<FileHandler>
    {
        private const string APP_FILES_ROOT_FOLDER = "GregsShoppingList";
        private const string SHOPPING_LIST_FILES_SUB_FOLDER = "ShoppingListFiles";
        private const string DATABASE_FILE_SUB_FOLDER = "ShoppingListDatabase";
        private const string SHOPPING_LIST_FILES_METADATA = "ShoppingListsMetadata";

        private const string JSON_FILE_EXTENSION = ".json";
        private const string INFO_FILE_EXTENSION = ".info";

        private static string AppFilesRootFolder;
        private static string ShoppingListFilesSubFolder;
        private static string DatabaseFileSubFolder; // TODO implement DB

        private static string ShoppingListFilesMetaData_FilePath;

        public FileHandler()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            AppFilesRootFolder = Path.Combine(documentsFolder, APP_FILES_ROOT_FOLDER);
            if (!Directory.Exists(AppFilesRootFolder)) { Directory.CreateDirectory(AppFilesRootFolder); }
            //
            ShoppingListFilesSubFolder = Path.Combine(AppFilesRootFolder, SHOPPING_LIST_FILES_SUB_FOLDER);
            if (!Directory.Exists(ShoppingListFilesSubFolder)) { Directory.CreateDirectory(ShoppingListFilesSubFolder); }
            //
            DatabaseFileSubFolder = Path.Combine(AppFilesRootFolder, DATABASE_FILE_SUB_FOLDER);
            if (!Directory.Exists(DatabaseFileSubFolder)) { Directory.CreateDirectory(DatabaseFileSubFolder); }
            //
            ShoppingListFilesMetaData_FilePath = Path.Combine(ShoppingListFilesSubFolder, SHOPPING_LIST_FILES_METADATA + INFO_FILE_EXTENSION);
        }

        public void WriteShoppingListFile(ShoppingList shoppingList, bool overwriteLatestShoppingList = true)
        {
            if (shoppingList is null) { return; }
            //
            string fileName = ConvertShoppingListNameToFileName(shoppingList.ShoppingListName);
            if (String.IsNullOrEmpty(fileName)) { return; }
            //
            string jsonString = JsonConvert.SerializeObject(shoppingList);
            //string jsonString = JsonSerializer.Serialize(shoppingList);
            string filePath = Path.Combine(ShoppingListFilesSubFolder, fileName);
            File.WriteAllText(filePath, jsonString);
            //
            if (overwriteLatestShoppingList) { WriteLatestShoppingListFileName(fileName); }
        }

        public ShoppingList ReadShoppingListFile(string fileName)
        {
            if (String.IsNullOrEmpty(fileName)) { return null; }
            //
            string filePath = Path.Combine(ShoppingListFilesSubFolder, fileName);
            string jsonString = File.ReadAllText(filePath);
            if (String.IsNullOrEmpty(jsonString)) { return null; }
            //
            ShoppingList shoppingList = JsonConvert.DeserializeObject<ShoppingList>(jsonString);
            //ShoppingList shoppingList = JsonSerializer.Deserialize<ShoppingList>(jsonString);
            //
            return shoppingList;
        }

        public ShoppingList ReadShoppingListFileByShoppingListName(string shoppingListName)
        {
            if (String.IsNullOrEmpty(shoppingListName)) { return null; }
            //
            string fileName = ConvertShoppingListNameToFileName(shoppingListName);            
            ShoppingList shoppingList = ReadShoppingListFile(fileName);
            //
            return shoppingList;
        }

        public ShoppingList ReadLatestShoppingListFile()
        {
            string shoppingListFileName = ReadLatestShoppingListFileName();
            if (String.IsNullOrEmpty(shoppingListFileName)) { return null; }
            //
            ShoppingList shoppingList = ReadShoppingListFile(shoppingListFileName);
            //
            return shoppingList;
        }

        public void WriteLatestShoppingListFileName(string shoppingListFileName)
        {
            if (String.IsNullOrEmpty(shoppingListFileName)) { return; }
            File.WriteAllText(ShoppingListFilesMetaData_FilePath, shoppingListFileName);
        }
        public string ReadLatestShoppingListFileName()
        {
            if (!File.Exists(ShoppingListFilesMetaData_FilePath)) { return String.Empty; }
            string shoppingListFileName = File.ReadAllText(ShoppingListFilesMetaData_FilePath);
            return shoppingListFileName;
        }

        public string ConvertShoppingListNameToFileName(string shoppingListName)
        {
            string fileName = shoppingListName;
            //
            foreach (char invalidLetter in System.IO.Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(invalidLetter.ToString(), "");
            }
            foreach (char invalidLetter in System.IO.Path.GetInvalidPathChars())
            {
                fileName = fileName.Replace(invalidLetter.ToString(), "");
            }
            fileName += JSON_FILE_EXTENSION;
            //
            return fileName;
        }
    }
}
