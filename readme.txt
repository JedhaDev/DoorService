DoorService => Implementation of WCF using tcpip protocol, hosted in their own consol application
DoorClient  => Implementation of WCF Client using WPF

1. verify the DoorService.exe.config for the connection string for SQL a key DBConnectionString (I used a local DB) 
2. start DoorService (for the first time, the DB is automatic created and feed it)
3. start DoorClient (you can start many instances as you want)

all was tested locally in one computer, in order to work in multiples computers, the endpoint configurations must be changed.
Unit tests are not included, but can be done upon request.

DoorClient functionality:
every client need to clic "Connect" button, after a click 2 process are executed, first the login itself, informing others instaces that a new client is connected, 
and second start to download from the DB all configured doors
everytime that someone click a door image, the door status is changed.

Kind Regards
Ricardo
