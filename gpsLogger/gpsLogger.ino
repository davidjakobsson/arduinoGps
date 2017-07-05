#include <SoftwareSerial.h>
#include "TinyGPS.h"


SoftwareSerial mySerial(3, 4); // RX, TX
TinyGPS gps;


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  mySerial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  
  //bool ready = false;
  //if (mySerial.available()) {
  //  char c = mySerial.read();
  //  Serial.write(c);
  //}


  bool ready = false;
  if (mySerial.available()) {
    char c = mySerial.read();
    //skriv rawdata
    Serial.write(c);
    if (gps.encode(c)) {
      ready = true;
    }
  }

  // Use actual data
  if (ready) {
    //gps
    // Use `gps` object
  }
}
