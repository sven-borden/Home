#include <SotwareSerial.h>

#define DEBUG

SoftwareSerial esp(11,10);

void setup()
{
    Serial.begin(9600);
    esp.begin(115200);

    sendData("AT+RST\r\n",2000);
    sendData("AT+CWMODE=2\r\n",1000);
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
            int B = ConvertHexaToLum(espread(),esp.read());
            Serial.println(G);

            // make close command
            String closeCommand = "AT+CIPCLOSE="; 
            closeCommand+=connectionId; // append connection id
            closeCommand+="\r\n";
            
            sendData(closeCommand,1000,DEBUG); // close connection
        }
    }
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
}


String sendData(String command, const int timeout, boolean debug)
{
    String response = "";
    
    esp8266.print(command); // send the read character to the esp8266
    
    long int time = millis();
    
    while( (time+timeout) > millis())
    {
      while(esp8266.available())
      {
        
        // The esp has data so display its output to the serial window 
        char c = esp8266.read(); // read the next character.
        response+=c;
      }  
    }
    
    if(debug)
    {
      Serial.print(response);
    }
    
    return response;
}