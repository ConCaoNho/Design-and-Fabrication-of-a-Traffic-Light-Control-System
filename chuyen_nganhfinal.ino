#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include "RTClib.h"
#include <ShiftRegister74HC595.h>
#include <Preferences.h> // Thêm để lưu dữ liệu

// LCD + RTC
LiquidCrystal_I2C lcd(0x27, 16, 2);
RTC_DS3231 rtc;
Preferences prefs; // Biến toàn cục cho Preferences

// DIP switch pins
const int dip1 = 2;   // NIGHT MODE
const int dip2 = 4;   // PRIORITY DIRECTION (dọc)
const int dip3 = 16;  // PRIORITY HORIZONTAL (ngang)
const int dip4 = 17;  // WARNING MODE

unsigned long lastSwitchTime = 0;
bool showTime = true;

// 74HC595 (4 IC)
ShiftRegister74HC595<4> sr(19, 18, 5);

// LED 7 segment digits
uint8_t digits[] = {
  0b11000000, 0b11111001, 0b10100100, 0b10110000,
  0b10011001, 0b10010010, 0b10000010, 0b11111000,
  0b10000000, 0b10010000
};

// Traffic light pins
#define D_YELLOW 32
#define D_RED    33
#define D_GREEN  25
#define D_LEFT   26
#define N_YELLOW 27
#define N_RED    14
#define N_GREEN  12
#define N_LEFT   13

int greenTime = 10;
int yellowTime = 3;
int leftTime = 3;
int redTime = greenTime + yellowTime;

String currentMode = "NORMAL";
String priorityDir = "";
bool manualMode = false;

void setup() {
  Serial.begin(115200);
  pinMode(dip1, INPUT);
  pinMode(dip2, INPUT);
  pinMode(dip3, INPUT);
  pinMode(dip4, INPUT);

  lcd.init();
  lcd.backlight();
  lcd.clear();
  if (!rtc.begin()) {
    Serial.println("Khong tim thay DS3231");
    while (1);
  }
  prefs.begin("traffic", false);
  greenTime = prefs.getInt("green", 10);
  yellowTime = prefs.getInt("yellow", 3);
  leftTime = prefs.getInt("left", 3);
  redTime = greenTime + yellowTime + leftTime;
  int pins[] = {D_YELLOW, D_RED, D_GREEN, D_LEFT, N_YELLOW, N_RED, N_GREEN, N_LEFT};
  for (int i = 0; i < 8; i++) {
    pinMode(pins[i], OUTPUT);
    digitalWrite(pins[i], LOW);
  }
}

void displayCountdown(int d, int n) {
  uint8_t data[4] = {
    digits[d / 10], digits[d % 10],
    digits[n / 10], digits[n % 10]
  };
  uint8_t realData[4] = {data[2], data[3], data[0], data[1]};
  sr.setAll(realData);
}

void allLightsOff() {
  digitalWrite(D_YELLOW, LOW);
  digitalWrite(D_RED, LOW);
  digitalWrite(D_GREEN, LOW);
  digitalWrite(D_LEFT, LOW);
  digitalWrite(N_YELLOW, LOW);
  digitalWrite(N_RED, LOW);
  digitalWrite(N_GREEN, LOW);
  digitalWrite(N_LEFT, LOW);
}

void updateLCD() {
  DateTime now = rtc.now();
  unsigned long currentMillis = millis();
  unsigned long interval = showTime ? 2000 : 5000;
  if (currentMillis - lastSwitchTime >= interval) {
    showTime = !showTime;
    lastSwitchTime = currentMillis;
    lcd.clear();
  }

  bool useDip = (manualMode && currentMode == "NORMAL");

  if (showTime) {
    lcd.setCursor(0, 0); lcd.print("Time:");
    if (now.hour() < 10) lcd.print("0"); lcd.print(now.hour()); lcd.print(":");
    if (now.minute() < 10) lcd.print("0"); lcd.print(now.minute()); lcd.print(":");
    if (now.second() < 10) lcd.print("0"); lcd.print(now.second());

    lcd.setCursor(0, 1); lcd.print("Date:");
    if (now.day() < 10) lcd.print("0"); lcd.print(now.day()); lcd.print("/");
    if (now.month() < 10) lcd.print("0"); lcd.print(now.month());
  } else {
    String modeDisplay = "NORMAL";

    if (currentMode == "WARNING" || (useDip && digitalRead(dip4) == LOW)) {
      modeDisplay = "WARNING ";
    } else if (currentMode == "NIGHT" || (useDip && digitalRead(dip1) == LOW)) {
      modeDisplay = "NIGHT   ";
    } else if (currentMode == "PRIORITY" || (useDip && (digitalRead(dip2) == LOW || digitalRead(dip3) == LOW))) {
      modeDisplay = "PRIORITY";
    }

    lcd.setCursor(0, 0);
    lcd.print("MODE: ");
    lcd.print(modeDisplay);

    lcd.setCursor(0, 1);
    if (modeDisplay == "PRIORITY") {
      lcd.print("PRIOR: ");
      if (currentMode == "PRIORITY") {
        lcd.print(priorityDir == "D" ? "VERTICAL " : "HORIZONTAL");
      } else {
        if (useDip && digitalRead(dip2) == LOW) lcd.print("DIRECTION ");
        else if (useDip && digitalRead(dip3) == LOW) lcd.print("HORIZONTAL");
        else lcd.print("UNKNOWN   ");
      }
    } else {
      lcd.setCursor(6, 1);
      lcd.print(manualMode ? "MANUAL" : "AUTO");
    }
  }
}

void handleManualIdle() {
  allLightsOff();
  displayCountdown(0, 0);
  updateLCD();
  delay(200);
}

void loop() {
  if (Serial.available()) {
    String cmd = Serial.readStringUntil('\n');
    cmd.trim();

    if (cmd.startsWith("SET_TIMES:")) {
      int p1 = cmd.indexOf(":") + 1;
      int p2 = cmd.indexOf(":", p1);
      int p3 = cmd.indexOf(":", p2 + 1);

      greenTime = cmd.substring(p1, p2).toInt();
      yellowTime = cmd.substring(p2 + 1, p3).toInt();
      leftTime = cmd.substring(p3 + 1).toInt();
      redTime = greenTime + yellowTime + leftTime;

      prefs.putInt("green", greenTime);
      prefs.putInt("yellow", yellowTime);
      prefs.putInt("left", leftTime);

      Serial.println("STATUS:TIMES_SET");
    }

    else if (cmd == "MANUAL_MODE_ON") {
      manualMode = true;
      Serial.println("STATUS:MANUAL_ON");
    }
    else if (cmd == "MANUAL_MODE_OFF") {
      manualMode = false;
      Serial.println("STATUS:MANUAL_OFF");
    }

    else if (cmd == "WARNING_MODE_ON") {
      currentMode = "WARNING";
      Serial.println("STATUS:WARNING_ON");
    }
    else if (cmd == "WARNING_MODE_OFF") {
      currentMode = "NORMAL";
      Serial.println("STATUS:WARNING_OFF");
    }

    else if (cmd == "NIGHT_MODE_ON") {
      currentMode = "NIGHT";
      Serial.println("STATUS:NIGHT_ON");
    }
    else if (cmd == "NIGHT_MODE_OFF") {
      currentMode = "NORMAL";
      Serial.println("STATUS:NIGHT_OFF");
    }

    else if (cmd.startsWith("PRIORITY_MODE_ON:")) {
      currentMode = "PRIORITY";
      priorityDir = cmd.substring(cmd.lastIndexOf(":") + 1);
      Serial.println("STATUS:PRIORITY_ON_" + priorityDir);
    }
    else if (cmd == "PRIORITY_MODE_OFF") {
      currentMode = "NORMAL";
      priorityDir = "";
      Serial.println("STATUS:PRIORITY_OFF");
    }
  }

  bool useDip = (manualMode && currentMode == "NORMAL");

  if (manualMode &&
      digitalRead(dip1) != LOW &&
      digitalRead(dip2) != LOW &&
      digitalRead(dip3) != LOW &&
      digitalRead(dip4) != LOW &&
      currentMode != "NORMAL 
      && currentMode != NIGHT
      && currentMode != WARNING
      && currrentMode != PIRIORITY") {
    handleManualIdle();
    return;
  }

  bool mode_night   = (currentMode == "NIGHT")   || (useDip && digitalRead(dip1) == LOW);
  bool warning_mode = (currentMode == "WARNING") || (useDip && digitalRead(dip4) == LOW);
  bool priority_d   = (currentMode == "PRIORITY" && priorityDir == "D") || (useDip && digitalRead(dip2) == LOW);
  bool priority_n   = (currentMode == "PRIORITY" && priorityDir == "N") || (useDip && digitalRead(dip3) == LOW);

  if (warning_mode) {
    allLightsOff();
    lcd.clear();
    lcd.setCursor(0, 0); lcd.print("CANH BAO: VANG");
    while ((currentMode == "WARNING") || (useDip && digitalRead(dip4) == LOW)) {
      digitalWrite(D_YELLOW, HIGH);
      digitalWrite(N_YELLOW, HIGH);
      displayCountdown(0, 0);
      updateLCD();
      delay(500);
      digitalWrite(D_YELLOW, LOW);
      digitalWrite(N_YELLOW, LOW);
      updateLCD();
      delay(500);
      if (Serial.available()) break;
    }
    lcd.clear();
    return;
  }

  int gT = mode_night ? 5 : greenTime;
  int yT = mode_night ? 2 : yellowTime;

  int gT_d = gT, gT_n = gT;
  if (priority_d && !priority_n) gT_n = 0;
  if (priority_n && !priority_d) gT_d = 0;

  if (priority_d && !priority_n) {
    allLightsOff();
    digitalWrite(D_GREEN, HIGH);
    digitalWrite(N_RED, HIGH);
    displayCountdown(0, 0);
    updateLCD();
    while ((currentMode == "PRIORITY" && priorityDir == "D") || (useDip && digitalRead(dip2) == LOW)) {
      delay(100);
      updateLCD();
      if (Serial.available()) return;
    }
    lcd.clear();
    return;
  }

  if (priority_n && !priority_d) {
    allLightsOff();
    digitalWrite(N_GREEN, HIGH);
    digitalWrite(D_RED, HIGH);
    displayCountdown(0, 0);
    updateLCD();
    while ((currentMode == "PRIORITY" && priorityDir == "N") || (useDip && digitalRead(dip3) == LOW)) {
      delay(100);
      updateLCD();
      if (Serial.available()) return;
    }
    lcd.clear();
    return;
  }

  if (gT_d > 0) {
    int totalRedN = gT_d + yT + leftTime;
    allLightsOff();
    digitalWrite(D_LEFT, HIGH);
    digitalWrite(D_RED, HIGH);
    digitalWrite(N_RED, HIGH);
    for (int i = leftTime; i >= 1; i--) {
      displayCountdown(i, totalRedN--);
      updateLCD();
      delay(1000);
      if (Serial.available()) return;
    }

    allLightsOff();
    digitalWrite(D_GREEN, HIGH);
    digitalWrite(N_RED, HIGH);
    for (int i = gT_d; i >= 1; i--) {
      displayCountdown(i, totalRedN--);
      updateLCD();
      delay(1000);
      if (Serial.available()) return;
    }

    allLightsOff();
    digitalWrite(D_YELLOW, HIGH);
    digitalWrite(N_RED, HIGH);
    for (int i = yT; i >= 1; i--) {
      displayCountdown(i, totalRedN--);
      updateLCD();
      delay(1000);
      if (Serial.available()) return;
    }
  }

  if (gT_n > 0) {
    int totalRedD = gT_n + yT + leftTime;
    allLightsOff();
    digitalWrite(N_LEFT, HIGH);
    digitalWrite(N_RED, HIGH);
    digitalWrite(D_RED, HIGH);
    for (int i = leftTime; i >= 1; i--) {
      displayCountdown(totalRedD--, i);
      updateLCD();
      delay(1000);
      if (Serial.available()) return;
    }

    allLightsOff();
    digitalWrite(N_GREEN, HIGH);
    digitalWrite(D_RED, HIGH);
    for (int i = gT_n; i >= 1; i--) {
      displayCountdown(totalRedD--, i);
      updateLCD();
      delay(1000);
      if (Serial.available()) return;
    }

    allLightsOff();
    digitalWrite(N_YELLOW, HIGH);
    digitalWrite(D_RED, HIGH);
    for (int i = yT; i >= 1; i--) {
      displayCountdown(totalRedD--, i);
      updateLCD();
      delay(1000);
      if (Serial.available()) return;
    }
  }

  if (!manualMode) {
    DateTime now = rtc.now();
    int h = now.hour();
    if (currentMode == "NORMAL" || currentMode == "NIGHT" || currentMode == "WARNING") {
      if (h >= 6 && h < 22) currentMode = "NORMAL";
      else if (h >= 22 && h <= 23) currentMode = "NIGHT";
      else currentMode = "WARNING";
    }
  }
}
