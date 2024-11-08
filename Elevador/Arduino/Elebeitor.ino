/*#include <Servo.h>;

const int analogIn = A5;
const int servoPin = 6;

const int buttonPin1 = 2;
const int buttonPin2 = 4;
int buttonState1 = 0;
int buttonState2 = 0;

const int motorpin11=10;
const int motorpin12=9;
const int motorpin21=8;
const int motorpin22=7;

char data;

Servo servo1;


void setup() {
  pinMode(buttonPin1, INPUT);
  pinMode(buttonPin2, INPUT);
  pinMode(motorpin11,OUTPUT);
  pinMode(motorpin12,OUTPUT);
  pinMode(motorpin21,OUTPUT);
  pinMode(motorpin22,OUTPUT);
  digitalWrite(motorpin11,LOW);
  digitalWrite(motorpin12,LOW);
  digitalWrite(motorpin21,LOW);
  digitalWrite(motorpin22,LOW);
  Serial.begin(9600);
  servo1.attach(servoPin);
}

void loop() {
  if (Serial.available() > 0)
  {
    data = Serial.read();
  
    
    if (data == 'a' || buttonState1 == HIGH)
    {
      servo1.write(0);  
      Serial.println("opening");
      delay(1000);
    }

    if (data == 'b' || buttonState2 == HIGH)
    {
      servo1.write(90);
      Serial.println("closing");
      delay(1000);
    }

    if (data == 'f') {
      digitalWrite(motorpin11,HIGH);
      digitalWrite(motorpin12,LOW);
      digitalWrite(motorpin21,HIGH);
      digitalWrite(motorpin22,LOW);
      Serial.println("up");
      delay(1000);
    }     
    else if(data == 'w') {
      digitalWrite(motorpin11,LOW);
      digitalWrite(motorpin12,HIGH);
      digitalWrite(motorpin21,LOW);
      digitalWrite(motorpin22,HIGH);
      Serial.println("down");
      delay(1000);
    }
    else
    {
    buttonState1 = digitalRead(buttonPin1);
    buttonState2 = digitalRead(buttonPin2);
  
    
    if (buttonState1 == HIGH)
    {
      servo1.write(0);  
      Serial.println("opening");
      delay(1000);
    }

    if (buttonState2 == HIGH)
    {
      servo1.write(90);
      Serial.println("closing");
      delay(1000);
    }

    if (data == 'f') {
      digitalWrite(motorpin11,HIGH);
      digitalWrite(motorpin12,LOW);
      digitalWrite(motorpin21,HIGH);
      digitalWrite(motorpin22,LOW);
      Serial.println("up");
      delay(1000);
    }     
    else if(data == 'w') {
      digitalWrite(motorpin11,LOW);
      digitalWrite(motorpin12,HIGH);
      digitalWrite(motorpin21,LOW);
      digitalWrite(motorpin22,HIGH);
      Serial.println("down");
      delay(1000);
    }
  }
}
}
*/

#include <Servo.h>
#include <HX711.h>

const int servoPin = 6;
const int buttonPin1 = 2;
const int buttonPin2 = 4;
int buttonState1 = 0;
int buttonState2 = 0;

const int motorpin11 = 10;
const int motorpin12 = 9;
const int motorpin21 = 8;
const int motorpin22 = 7;

const int smokeSensorPin = A0; // Pin analógico del sensor MQ-2
const int smokeThreshold = 150; // Umbral para detectar humo

const int weightDataPin = A5; // Pin de datos del HX711
const int weightClockPin = A4; // Pin de reloj del HX711
const float weightThreshold = 1000.0; // Umbral de peso en gramos (1 kilogramo)
const unsigned long weightDelay = 5000; // Tiempo de espera en milisegundos después de detectar peso elevado

HX711 scale; // Crear objeto del sensor de peso HX711

char data;
bool smokeDetected = false; // Variable para detener el sistema al detectar humo
bool weightDetected = false; // Variable para detener el sistema al detectar peso elevado
unsigned long smokeDetectionTime = 0; // Tiempo de detección de humo
unsigned long weightDetectionTime = 0; // Tiempo de detección de peso elevado
const unsigned long smokeDelay = 5000; // Tiempo en milisegundos para esperar después de detectar humo

Servo servo1;
unsigned long motorStartTime = 0;
const unsigned long motorRunTime = 2000;
bool motorRunning = false;

void setup() {
  pinMode(buttonPin1, INPUT);
  pinMode(buttonPin2, INPUT);
  pinMode(motorpin11, OUTPUT);
  pinMode(motorpin12, OUTPUT);
  pinMode(motorpin21, OUTPUT);
  pinMode(motorpin22, OUTPUT);

  digitalWrite(motorpin11, LOW);
  digitalWrite(motorpin12, LOW);
  digitalWrite(motorpin21, LOW);
  digitalWrite(motorpin22, LOW);

  if (Serial) {
    Serial.begin(9600);
  }
  
  servo1.attach(servoPin);

  // Configuración del sensor de peso HX711
  scale.begin(weightDataPin, weightClockPin);
  scale.set_scale(2280.f); // Calibración del sensor (ajusta el valor según tu configuración)
  scale.tare(); // Ajustar el peso inicial a cero
}

void loop() {
  // Leer el valor del sensor de humo si no se ha detectado humo previamente
  if (!smokeDetected) {
    int sensorValue = analogRead(smokeSensorPin);
    if (Serial) {
      Serial.print("Sensor de Humo Valor: ");
      Serial.println(sensorValue);
    }

    // Verificar si el valor del sensor supera el umbral de humo
    if (sensorValue > smokeThreshold) {
      if (Serial) Serial.println("Humo detectado. Deteniendo el sistema.");
      smokeDetected = true; // Detener el sistema
      smokeDetectionTime = millis(); // Guardar el tiempo de detección
    }
  }

  // Leer el valor del sensor de peso si no se ha detectado un peso elevado previamente
  if (!weightDetected) {
    float weight = scale.get_units(); // Leer el peso en gramos
    if (Serial) {
      Serial.print("Peso detectado: ");
      Serial.print(weight);
      Serial.println(" g");
    }

    // Verificar si el peso supera el umbral
    if (weight > weightThreshold) {
      if (Serial) Serial.println("Peso elevado detectado. Deteniendo el sistema.");
      weightDetected = true; // Detener el sistema
      weightDetectionTime = millis(); // Guardar el tiempo de detección
    }
  }

  // Si se ha detectado humo o peso elevado, detener el sistema temporalmente
  if (smokeDetected || weightDetected) {
    // Apagar motores y detener el servomotor
    digitalWrite(motorpin11, LOW);
    digitalWrite(motorpin12, LOW);
    digitalWrite(motorpin21, LOW);
    digitalWrite(motorpin22, LOW);

    // Verificar si ha pasado el tiempo de espera después de detectar humo
    if (smokeDetected && (millis() - smokeDetectionTime >= smokeDelay)) {
      if (Serial) Serial.println("Tiempo de espera terminado. Reiniciando el sistema.");
      smokeDetected = false; // Reiniciar el sistema por humo
    }

    // Verificar si ha pasado el tiempo de espera después de detectar peso elevado
    if (weightDetected && (millis() - weightDetectionTime >= weightDelay)) {
      if (Serial) Serial.println("Tiempo de espera para peso terminado. Reiniciando el sistema.");
      weightDetected = false; // Reiniciar el sistema por peso elevado
    }

    return; // Salir de loop() para evitar más acciones
  }

  // Control del servo mediante los botones
  buttonState1 = digitalRead(buttonPin1);
  buttonState2 = digitalRead(buttonPin2);

  if (data == 'a') {
    servo1.write(0);
    if (Serial) Serial.println("opening");
    delay(1000);
    data = 0;
  } 
  else if (data == 'b') {
    servo1.write(45);
    if (Serial) Serial.println("closing");
    delay(1000);
    data = 0;
  }

  // Movimiento del motor con comandos seriales y tiempo de ejecución limitado
  if ((data == 'f' || buttonState1 == HIGH ) && !motorRunning) {
    digitalWrite(motorpin11, HIGH);
    digitalWrite(motorpin12, LOW);
    digitalWrite(motorpin21, HIGH);
    digitalWrite(motorpin22, LOW);
    if (Serial) Serial.println("up");
    motorStartTime = millis();
    motorRunning = true;
    data = 0;
  } 
  else if ((data == 'w' || buttonState2 == HIGH ) && !motorRunning) {
    digitalWrite(motorpin11, LOW);
    digitalWrite(motorpin12, HIGH);
    digitalWrite(motorpin21, LOW);
    digitalWrite(motorpin22, HIGH);
    if (Serial) Serial.println("down");
    motorStartTime = millis();
    motorRunning = true;
    data = 0;
  }

  // Detener el motor después de que se cumpla el tiempo
  if (motorRunning && (millis() - motorStartTime >= motorRunTime)) {
    digitalWrite(motorpin11, LOW);
    digitalWrite(motorpin12, LOW);
    digitalWrite(motorpin21, LOW);
    digitalWrite(motorpin22, LOW);
    if (Serial) Serial.println("motor stopped");
    motorRunning = false;
  }

  // Leer datos del puerto serial solo si está disponible
  if (Serial && Serial.available() > 0) {
    data = Serial.read();
  }
}
