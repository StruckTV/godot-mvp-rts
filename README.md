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

## Testing & Troubleshooting

### Server Status Check
If you are unsure if the server is running correctly, run the helper script in the root directory:

```bash
./check_server_status.sh
```

This script will verify:
- Docker is installed and running.
- The Nakama and Postgres containers are active.
- The Nakama API is reachable.

### In-Game Connection Test
If the server seems to be running but the game isn't connecting, run the **Connection Test Scene**:

1. Open the project in Godot.
2. In the FileSystem, open `Scenes/ConnectionTest.tscn`.
3. Press **F6** (Run Current Scene).

This will display a diagnostic screen showing exactly where the connection is failing (e.g., Auth failed, Socket failed, etc.).

## Features (MVP)

- **Local Backend**: Nakama + Postgres via Docker.
- **Void Island**: Simple UI Hub.
- **Extraction Ops**: Basic 3D scene with Threat Level timer and Extraction logic.
- **Networking**: Connects to local Nakama instance via `NetworkManager`.
