#include <SoftwareSerial.h>
#define DEBUG true
#define REDPIN 9
#define GREENPIN 6
#define BLUEPIN 5

SoftwareSerial esp(11,10);

void setup()
{
    Serial.begin(9600);
    //esp.begin(115200);
    //sendData("AT+UART_DEF=9600,8,1,0,0",1000);
    esp.begin(9600);
  pinMode(REDPIN,OUTPUT);
  pinMode(GREENPIN,OUTPUT);
  pinMode(BLUEPIN,OUTPUT);
  analogWrite(REDPIN,255); 
    sendData("AT+CWMODE=1\r\n",1000);
    sendData("AT+CWLAP\r\n",5000);
    sendData("AT+CWJAP=\"P600\",\"Y0urn0ta110weD\"\r\n",10000);
    sendData("AT+CIFSR\r\n",1000); // get ip address
    sendData("AT+CIPMUX=1\r\n",1000); // configure for multiple connections
    sendData("AT+CIPSERVER=1,80\r\n",1000); // turn on server on port 80
}

void loop()
{
    if(esp.available())
    {
        if(esp.find("+IPD,"))
        {
            delay(1000);;
            int connectionId = esp.read()-48;//substract 48 because '0' char is at 48th position in ASCII table
            
            esp.find("red=");
            int R = ConvertHexaToLum(esp.read(),esp.read());

            esp.find("green=");
            int G = ConvertHexaToLum(esp.read(),esp.read());

            esp.find("blue=");
            int B = ConvertHexaToLum(esp.read(),esp.read());
            //Serial.println(B);
            // make close command
            String closeCommand = "AT+CIPCLOSE="; 
            closeCommand+=connectionId; // append connection id
            closeCommand+="\r\n";
            sendHTTPResponse(connectionId,"RED GREEN BLUE OK");
            SetLed(R,G,B);
            //sendData(closeCommand,1000); // close connection
        }
    }
}

void SetLed(int R, int G, int B)
{
  analogWrite(REDPIN,R);
  analogWrite(GREENPIN,G);
  analogWrite(BLUEPIN,B);
}

int ConvertHexaToLum(int high, int low)
{
    int value = 0;
    if(high < 65)//value between 0 & 9
    {
        value += (high-48)*16;
    }
    else
    {
        value += (high-65)*16;
    }
    if(low < 65)
    {
        value += (low-48);
    }
    else
    {
        value += (low-65);
    }
    return value;
}


String sendData(String command, const int timeout)
{
    String response = "";
    
    esp.print(command); // send the read character to the esp8266
    
    long int time = millis();
    
    while( (time+timeout) > millis())
    {
      while(esp.available())
      {
        
        // The esp has data so display its output to the serial window 
        char c = esp.read(); // read the next character.
        response+=c;
      }  
    }
    
    if(true)
    {
      Serial.print(response);
    }
    
    return response;
}

void sendHTTPResponse(int connectionId, String content)
{
     
     // build HTTP response
     String httpResponse;
     String httpHeader;
     // HTTP Header
     httpHeader = "HTTP/1.1 200 OK\r\nContent-Type: text/html; charset=UTF-8\r\n"; 
     httpHeader += "Content-Length: ";
     httpHeader += content.length();
     httpHeader += "\r\n";
     httpHeader +="Connection: close\r\n\r\n";
     httpResponse = httpHeader + content + " "; // There is a bug in this code: the last character of "content" is not sent, I cheated by adding this extra space
     sendCIPData(connectionId,httpResponse);
}

void sendCIPData(int connectionId, String data)
{
   String cipSend = "AT+CIPSEND=";
   cipSend += connectionId;
   cipSend += ",";
   cipSend +=data.length();
   cipSend +="\r\n";
   sendCommand(cipSend,1000);
   sendData(data,1000);
}

String sendCommand(String command, const int timeout)
{
    String response = "";
           
    esp.print(command); // send the read character to the esp8266
    
    long int time = millis();
    
    while( (time+timeout) > millis())
    {
      while(esp.available())
      {
        
        // The esp has data so display its output to the serial window 
        char c = esp.read(); // read the next character.
        response+=c;
      }  
    }
    
    if(true)
    {
      Serial.print(response);
    }
    
    return response;
}
