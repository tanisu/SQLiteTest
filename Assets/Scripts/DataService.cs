using System;
using System.Collections.Generic;
using SQLite4Unity3d;
using System.Linq;
using UnityEngine;

public static class DataService
{
    private static SQLiteConnection _database;

    public static void InitDatabase(string databaseName)
    {
        try
        {
            string DBPath = $"Assets/StreamingAssets/{databaseName}";
            _database = new SQLiteConnection(DBPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to initialize database: {e.Message}");
        }
    }

    public static void CreateTable()
    {
        try
        {
            _database.CreateTable<Player>();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to create table: {e.Message}");
        }
    }

    public static void InsertPlayer(Player player) 
    {
        try
        {
            _database.Insert(player);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to insert player: {e.Message}");
        }
    }

    public static List<Player> GetAllPlayers()
    {
        try
        {
            return _database.Table<Player>().OrderByDescending(p => p.Score).ToList();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to get all players: {e.Message}");
            return new List<Player>(); // エラーが発生した場合は空のリストを返す
        }
    }

    public static void DeletePlayers()
    {
        try
        {
            _database.DeleteAll<Player>();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to delete players: {e.Message}");
        }
    }

    public static Player GetPlayerByName(string playerName)
    {
        try
        {
            return _database.Table<Player>().FirstOrDefault(p => p.Name == playerName);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to get player by name: {e.Message}");
            return null; // エラーが発生した場合はnullを返す
        }
    }

    public static void UpdatePlayerData(Player player)
    {
        try
        {
            _database.Update(player);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to update player data: {e.Message}");
        }
    }
}

public class Player
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
}
