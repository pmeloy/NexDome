
#define Computer Serial
#define Wireless Serial1

enum confModes {NONE, WRITE, READ, DEFAULTS};
char wirelessCharacter, computerCharacter;
String WirelessBuffer, ComputerBuffer;

unsigned long int NextCommand, spacing = 1000;
byte WirelessConfigState = 0;
int configWirelessMode;
byte ceVal, smVal, roVal, apVal, soVal;
int idVal, spVal, stVal, gtVal;
bool introDone = false, initialReadDone = false;;
void setup()
{
  Computer.begin(9600);
  Wireless.begin(9600);
  delay(1100);
  StartConfigWireless(READ);

}

void loop()
{
  if (introDone == false && initialReadDone == true)
  {
    Computer.println("Enter 'idxxxx' to set module identity. All modules MUST have the same identity to communicate");
    Computer.println("Available commands:");
    Computer.println("    'rc' Read configuration from XBee");
    Computer.println("    're' Reset XBee to factory defaults");
    Computer.println("    'id<value>' Set identity number e.g. id5555");
    Computer.println("    'wc' Write configuration to XBee");
    introDone = true;
  }
  if (Computer.available() > 0)
  {
    ReceiveComputer();
  }

  if (Wireless.available())
  {
    ReceiveWireless();
  }
}

void ReceiveComputer()
{
  computerCharacter = Computer.read();

  if (computerCharacter == '\r' || computerCharacter == '\n')
  {
    // End of message
    if (ComputerBuffer.length() > 0)
    {
      ProcessComputer();
      ComputerBuffer = "";
    }
  }
  else
  {
    ComputerBuffer += String(computerCharacter);
  }
}

void ProcessComputer()
{
  String cmd = "", value = "";
  cmd = ComputerBuffer.substring(0, 2);
  value = ComputerBuffer.substring(2);

  if (cmd.equals("wc"))
  {
    Computer.println("Write configuration to XBee");
    StartConfigWireless(WRITE);
  }
  else if (cmd.equals("rc"))
  {
    Computer.println("Read configuration from XBee");
    StartConfigWireless(READ);
  }
  else if (cmd.equals("re"))
  {
    Computer.println("Set XBee to factory defaults");
    StartConfigWireless(DEFAULTS);
  }
  else if (cmd.equals("id"))
  {
    if (value.toInt() > 0)
    {
      idVal = value.toInt();
      Computer.println("id will be changed to " + value);
      Computer.println("Use wc to write changes to XBee");
    }
    else
    {
      Computer.println("Invalid id");
    }
  }
  else if (cmd.equals("ce"))
  {
	  ceVal = value.toInt();
	  Computer.println("Coordinator mode will be changed to " + value);
	  Computer.println("Use wc to write changes to XBee");
  }
  else
  {
    Computer.println("Computer: " + cmd + " " + value);
    //Wireless.println(ComputerBuffer);
  }
}

void ReceiveWireless()
{
  wirelessCharacter = Wireless.read();

  if (wirelessCharacter == '\r' || wirelessCharacter == '\n' || wirelessCharacter == '#')
  {
    // End of message
    if (WirelessBuffer.length() > 0)
    {
      if (configWirelessMode == NONE )
      {
        ProcessWireless();
      }
      else if (configWirelessMode == WRITE)
      {
        WriteConfig();
      }
      else if (configWirelessMode == READ)
      {
        ReadWirelessConfig();
      }
      else if (configWirelessMode == DEFAULTS)
      {
        XBeeDefaults();
      }
      WirelessBuffer = "";
    }
  }
  else
  {
    WirelessBuffer += String(wirelessCharacter);
  }
}

void StartConfigWireless(int mode)
{
  delay(2000);
  WirelessConfigState = 0;
  configWirelessMode = mode;
  Computer.println("Sending +++");
  Wireless.print("+++");
  delay(1000);
}

void ReadWirelessConfig()
{
  if (WirelessConfigState == 0)
  {
    Wireless.println("ATID,CE,SM,SO,SP,ST,RO,AP,VR,HV,CN");
  }

  switch (WirelessConfigState)
  {
    case 1:
      idVal = WirelessBuffer.toInt();
      Computer.println("(ID) identity: " + String(idVal));
      break;
    case 2:
      ceVal = WirelessBuffer.toInt();
      Computer.println("(CE) Coordinator Mode: " + String(ceVal));
      break;
    case 3:
      smVal = WirelessBuffer.toInt();
      Computer.println("(SM) Sleep Mode: " + String(smVal));
      break;
    case 4:
      spVal = WirelessBuffer.toInt();
      Computer.println("(SO) Sleep Options: " + String(soVal));
      break;
    case 5:
      spVal = WirelessBuffer.toInt();
      Computer.println("(SP) Time until Sleep: " + String(spVal));
      break;
    case 6:
      stVal = WirelessBuffer.toInt();
      Computer.println("(ST) Sleep Time: " + String(stVal));
      break;
    case 7:
      roVal = WirelessBuffer.toInt();
      Computer.println("(RO) Packetization Timeout: " + String(roVal));
      break;
    case 8:
      apVal = WirelessBuffer.toInt();
      Computer.println("(AP) API Mode: " + String(apVal));
      break;
    case 9:
      Computer.println("(VR) Firmware version: " + WirelessBuffer);
      break;
    case 10:
      Computer.println("(HV) Hardware version: " + WirelessBuffer);
      break;
    case 11:
      configWirelessMode = 0;
      initialReadDone = true;
      Computer.println("Finished");
      break;
  }
  WirelessConfigState++;
  //Computer.println(String(WirelessConfigState) + " " + WirelessBuffer);

}
void WriteConfig()
{
  if (WirelessConfigState == 0 )
  {
    Computer.println("0 +++ Result:" + WirelessBuffer);
    String configString = "AT";
    configString += "ID" + String(idVal);
	configString += ",CE" + String(ceVal);
	configString += ",RO0,PL0,SM0,SP0,ST1,AP0,WR,CN";
    Computer.println("Writing " + configString);
    Wireless.println(configString);
    WirelessConfigState++;
  }
  else
  {
    switch (WirelessConfigState)
    {
      case 1:
        Computer.println(String(WirelessConfigState) + " ID Result:" + WirelessBuffer);
        break;
      case 2:
        Computer.println(String(WirelessConfigState) + " CE Result:" + WirelessBuffer);
        break;
      case 3:
        Computer.println(String(WirelessConfigState) + " RO Result:" + WirelessBuffer);
        break;
      case 4:
        Computer.println(String(WirelessConfigState) + " PL Result:" + WirelessBuffer);
        break;
      case 5:
        Computer.println(String(WirelessConfigState) + " SM Result:" + WirelessBuffer);
        break;
      case 6:
        Computer.println(String(WirelessConfigState) + " SP Result:" + WirelessBuffer);
        break;
      case 7:
        Computer.println(String(WirelessConfigState) + " ST Result:" + WirelessBuffer);
        break;
      case 8:
        Computer.println(String(WirelessConfigState) + " AP Result:" + WirelessBuffer);
        break;
      case 9:
        Computer.println(String(WirelessConfigState) + " WR Result:" + WirelessBuffer);
        configWirelessMode = 0;
        Computer.println("Write Complete");
        break;
    }
    WirelessConfigState++;
  }
}

void XBeeDefaults()
{
  if (WirelessConfigState == 0)
  {
    Wireless.println("ATRE,CN");
    WirelessConfigState++;
  }
  else
  {
    Computer.println(WirelessBuffer);
  }
  if (WirelessConfigState > 1) configWirelessMode = 0;
}
void ProcessWireless()
{
  Computer.println("Wireless received: " + WirelessBuffer);
}
