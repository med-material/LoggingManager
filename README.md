# LoggingManager
Provides a UnityPackage for logging data to CSV and to MySQL databases. For examples of using the LoggingManager, see the included [LoggingExample.cs](https://github.com/med-material/LoggingManager/blob/master/Assets/LoggingManager/LoggingExample.cs).

## CSV Logging
CSV Logs are stored by default in your computer's Documents folder. The file path can also be overriden by a custom path, set from Unity (be aware that the custom file path may not be transferable to other computers and fail silently.)

## ConnectToMySQL (Optional)
![ConnectToMySQL Dialog](https://raw.githubusercontent.com/med-material/ConnectToMySQL/master/connect-to-mysql-image.png)

The LoggingManager optionally supports sending data to a MySQL database.
When enabled, a dialog will ask for credentials at runtime and save them to disk (and never ask again).
Optionally the credentials can be compiled into binaries for deployment purposes.

Students should get credentials and database via their supervisor.

## Good Logging Practices
 - Log `System.DateTime.Now` (requires `using System;`) (This is automatically done by LoggingManager).
 - Log `Time.Framecount` so you can investigate issue of game lag and verify the timing of events. (This is done automatically by LoggingManager)
 - Log a `ParticipantID` to assign a unique ID to each participant.
 - Log a `TestID` to assign a unique ID to each test. Even if you do one test per participants, sometimes tests are redone, due to e.g. mistakes in the procedure or technological faults.
 - Rather than counting the occurance of something in Unity (aggregating data), log important events every frame. This way we can backtrack what happened. If I/O performance is a problem, then write initially to memory.
  - Log `SceneManager.GetActiveScene()` to log current scene (requires `using UnityEngine.SceneManagement;`).
 - Log `transform.eulerAngles` to log rotation of an object - you don't want to log object rotation, only to find out that you accidentically logged Quaternion coordinates (and forgot the `transform.rotation.w` coordinate).
 - Log `transform.localPosition` in addition to `transform.position`. Generally, `transform.position` will work fine, except if your VR scene calibrates by rotating some parent object. This will leave you with inconsistent coordinates between participants. Log both X, Y and Z coordinates.
 - Version number of what is running somehow. Need to investigate how to do this with Unity.
 - If you log an event which has a start, a duration and and end, make sure you always measure all three. Measuring Duration fx with Time.deltaTime might not be as reliable as measure distance between two System.Datetime.Now timestamps.
 
## For Eye Tracking
  - For Eye Tracking, log `hemi_gaze` in addition to any transformed `world_gaze`. When Unity transforms viewport points to world points, there may be a certain inaccuracy.
