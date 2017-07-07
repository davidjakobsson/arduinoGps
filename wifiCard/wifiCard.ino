
#include <SoftwareSerial.h>

SoftwareSerial mySerial(7, 6); // RX, TX

void setup() {

  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW); 
  // put your setup code here, to run once:
  Serial.begin(57600);
  mySerial.begin(115200);
  Serial.write("Wifi");
}

void loop() {
  // put your main code here, to run repeatedly:

  if (mySerial.available()) {
    char c = mySerial.read();
    //skriv rawdata
    Serial.write(c);
    digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(200);                       // wait for a second
    digitalWrite(LED_BUILTIN, LOW);
  }

  if(Serial.available()){
    mySerial.write(Serial.read());  
  }

}
