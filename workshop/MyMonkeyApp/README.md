# Monkey Explorer Console Application

A C# console application that allows users to explore and learn about various monkey species from around the world.

## Features

- 🐵 **List All Monkeys**: View all available monkey species with their habitat and population information
- 🔍 **Search by Name**: Find specific monkeys by entering their name (case-insensitive)
- 🎲 **Random Monkey**: Discover a randomly selected monkey species
- 🎨 **ASCII Art**: Beautiful visual elements and emojis for enhanced user experience
- 📊 **Detailed Information**: View habitat, population, conservation status, and detailed descriptions

## Available Monkey Species

The application includes 8 different monkey species:
- Baboon
- Capuchin Monkey
- Japanese Macaque
- Golden Lion Tamarin
- Proboscis Monkey
- Spider Monkey
- Howler Monkey
- Mandrill

## How to Run

1. Make sure you have .NET 8.0 SDK installed
2. Navigate to the project directory
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

## Usage

When you run the application, you'll see a welcome screen with a main menu offering four options:

1. **List All Monkeys** (enter `1` or `list`)
2. **Search Monkey by Name** (enter `2` or `search`)
3. **Random Monkey** (enter `3` or `random`)
4. **Exit** (enter `4`, `exit`, or `quit`)

The application supports both numeric and text-based commands for ease of use.

## Technical Details

- **Target Framework**: .NET 8.0
- **Language**: C# with XML documentation
- **Architecture**: 
  - `Models/Monkey.cs`: Data model for monkey information
  - `Helpers/MonkeyHelper.cs`: Static class for data management and operations
  - `Helpers/AsciiArt.cs`: Visual elements and ASCII art
  - `Program.cs`: Main application logic and user interface

## Code Features

- Comprehensive XML documentation for all classes and methods
- Clean separation of concerns with organized folder structure
- Error handling for invalid inputs
- Console input/output optimization for both interactive and redirected scenarios
- Emoji and Unicode support for enhanced visual appeal

## Conservation Information

The application includes real conservation status information to help raise awareness about monkey species and their protection needs.