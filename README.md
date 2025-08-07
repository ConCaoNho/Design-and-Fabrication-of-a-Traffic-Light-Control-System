# 🚦 Traffic Light Control System

**Final-Year Project: Design and Fabrication of a Traffic Light Control System**  
This project presents a fully functional traffic light control system using microcontrollers, integrated with a Windows C# application for real-time configuration and monitoring.

---

## 📌 Features

- **Control of 8 traffic signal LEDs**: Red, Yellow, Green, and Left-Turn lights for both vertical and horizontal directions.
- **Countdown Display**: 7-segment LEDs clearly show remaining time for each traffic light phase.
- **Real-time LCD I2C Display**: Shows current time and active operating mode (Auto / Manual / Night / Warning / Priority).
- **C# WinForms Application**:
  - Allows users to configure phase durations for each light.
  - Enables or disables modes like Night Mode, Warning Mode, and Priority Mode.
- **Multiple Modes Supported**:
  - **Automatic Mode**: Lights change according to preconfigured durations.
  - **Manual Mode**: Operator can trigger light phases manually.
- **Professional PCB Design**: Transitioned from hand-crafted boards to professionally fabricated PCBs.
- **Stable & Reliable System**: Operates as expected in all modes and ready for real-world deployment.

---

## 📷 System Overview

| Component                  | Description                                      |
|---------------------------|--------------------------------------------------|
| 👨‍💻 Microcontroller        | ESP32 38PIN                                      |
| 💡 LEDs                   | 8 signal lights for 2 directions                 |
| ⏱  7-segment display      | Countdown timer for traffic phases   IC 74HC595  |
| 🖥  LCD I2C                | Show time + operating mode                       |
| 🪛 C# WinForms App        | Send time configs and control modes             |
| 🔌 Communication          | UART (Serial) between Arduino & C# app           |

---

## 📂 Folder Structure

