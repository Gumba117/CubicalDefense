using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveMamager
{
    public static void SavePlayerScore(ScoreManager puntaje)
    {
        PlayerData playerData = new PlayerData(puntaje);//
        string dataPath = Application.persistentDataPath + "/puntaje.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerScore()
    {
        string dataPath = Application.persistentDataPath + "/puntaje.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("No se encontro el archivo de guardado");
            return null;
        }
    }


}