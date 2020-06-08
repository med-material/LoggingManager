# ConnectToMySQL
![ConnectToMySQL Dialog](https://raw.githubusercontent.com/med-material/ConnectToMySQL/master/connect-to-mysql-image.png)

Provides a UnityPackage for use to interface with a MySQL database (See Builds/ folder).
The package will ask for credentials at runtime and save them to disk (and never ask again).
Optionally the credentials can be compiled into binaries for deployment purposes.

Students should get credentials via their supervisor.

# How To Use
The ConnectToMySQL package parses a String Dictionary with one or more lists of strings representing columns in MySQL.
In C Sharp you can declare such a dictionary with `private Dictionary<string, List<string>> logCollection = new Dictionary<string, List<string>>();`

When adding a column you then need to first create a list, fx:
`logCollection["Date"] = new List<string>();`

And you can then add data to the list:
`logCollection["Date"].Add(System.DateTime.Now.ToString("yyyy-MM-dd"));`

It is important that you keep your lists in sync, length-wise. You can do so, fx by having a function where all lists are always populated.

```
    public void LogData(GameData gameData) {
        logCollection["Event"].Add(System.Enum.GetName(typeof(GameState), gameData.gameState));
        logCollection["Date"].Add(System.DateTime.Now.ToString("yyyy-MM-dd"));
        logCollection["Timestamp"].Add(System.DateTime.Now.ToString("HH:mm:ss.ffff"));
        logCollection["TargetFabInputRate"].Add(gameData.fabInputRate.ToString());
        logCollection["TargetRecognitionRate"].Add(gameData.recognitionRate.ToString());
        logCollection["StartPolicyReview"].Add(gameData.startPolicyReview.ToString());
        logCollection["Trials"].Add(gameData.trials.ToString());
        logCollection["InterTrialIntervalSeconds"].Add(gameData.interTrialIntervalSeconds.ToString());
        logCollection["InputWindowSeconds"].Add(gameData.inputWindowSeconds.ToString());
        logCollection["GameState"].Add(System.Enum.GetName(typeof(GameState), gameData.gameState));
        logCollection["FabAlarmFixationPoint"].Add(gameData.noInputReceivedFabAlarm.ToString());
        logCollection["FabAlarmVariability"].Add(gameData.fabAlarmVariability.ToString());
    }
```

When you finish creating the logCollection, simply call the function `connectToMySQL.AddToUploadQueue(logs);` to add logs to the queue and call `connectToMySQL.UploadNow();` to attempt to upload the code to the database. If for whatever reason uploading fails, the ConnectToMySQL script dumps the logs to disk and will try to upload them again when the application is started again. On Windows you can find the dumped logs at `%AppData%\LocalLow\$ORGANISATION\$APPNAME\Data`

You can find examples of ConnectToMySQL in [LoggingManager.cs](https://github.com/med-material/TunnelGoalFittsTests/blob/master/assets/Scripts/Managers/LoggingManager.cs#L106) from TunnelGoalFittsTest.
