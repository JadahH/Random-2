# Random Generators in C#

## 📌 Overview
This project includes three random generators:
1. **Normal Distribution Generator** – Generates random numbers with a given mean and standard deviation.
2. **Password Generator** – Creates a password with letters (A-Z, a-z), numbers (0-9), and underscores (_).
3. **Color Generator** – Generates a random color in **HEX** and **RGB** format.

## 🛠 How It Works
- **GenerateNormalRandom(mean, stdDev)** → Returns a number that follows a normal distribution.
- **GeneratePassword(length)** → Returns a random password of the given length.
- **GenerateRandomColor()** → Returns a **HEX color string** and an **RGB tuple (R, G, B)**.

## ✅ Testing
- Uses **XUnit** for unit tests.
- Tests check:
  - Normal distribution stats (mean and std deviation).
  - Password length and character set.
  - Color validity (RGB in range 0-255 and HEX format).

## 🚀 How to Run
1. **Build the project**:
   ```sh
   dotnet build