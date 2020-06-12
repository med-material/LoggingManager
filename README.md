# ConnectToMySQL
![ConnectToMySQL Dialog](https://raw.githubusercontent.com/med-material/ConnectToMySQL/master/connect-to-mysql-image.png)

Provides a UnityPackage for use to interface with a MySQL database (See Builds/ folder).
The package will ask for credentials at runtime and save them to disk (and never ask again).
Optionally the credentials can be compiled into binaries for deployment purposes.

Students should get credentials via their supervisor.

# How To Use with LoggingManager
ConnectToMySQL now includes a generic LoggingManager which can log to CSV and to SQL, so you won't need to interface with ConnectToMySQL directly. For examples of using the LoggingManager, see the included [LoggingExample.cs](https://github.com/med-material/ConnectToMySQL/blob/master/Assets/ConnectToMySQL/LoggingExample.cs).
