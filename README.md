# Legions of the Void - MVP

This is an MVP implementation of "Legions of the Void" as described in the GDD, set up for local development.

## Prerequisites

- **Godot 4.2+ (.NET Version)**: You must have the .NET version of Godot installed.
- **Docker & Docker Compose**: To run the local backend server (Nakama).
- **.NET SDK 8.0**: To build the C# project.

## Setup & Running

### 1. Start the Local Server

Run the following command in the root of the repository to start Nakama and Postgres:

```bash
docker-compose up -d
```

This will start:
- Nakama Console: http://localhost:7351 (Default admin: `admin` / `password`)
- Nakama API: http://localhost:7350

### 2. Run the Game

1. Open Godot 4 (.NET version).
2. Import the project located in the `LegionsOfTheVoid` folder.
3. Build the solution (Top right corner "Build" button).
4. Run the project (Press F5).

The game will authenticate with the local Nakama server and show the "Void Island" menu.

## Features (MVP)

- **Local Backend**: Nakama + Postgres via Docker.
- **Void Island**: Simple UI Hub.
- **Extraction Ops**: Basic 3D scene with Threat Level timer and Extraction logic.
- **Networking**: Connects to local Nakama instance.
