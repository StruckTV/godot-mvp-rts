#!/bin/bash

echo "=== Legions of the Void: Server Status Check ==="

# 1. Check dependencies
if ! command -v docker &> /dev/null; then
    echo "[ERROR] Docker is not installed or not in your PATH."
    exit 1
fi

if ! command -v curl &> /dev/null; then
    echo "[ERROR] curl is not installed."
    exit 1
fi

# 2. Check Containers
echo "Checking Docker containers..."
if [ "$(docker ps -q -f name=nakama)" ]; then
    echo "[PASS] Nakama container is running."
else
    echo "[FAIL] Nakama container is NOT running."
    echo "Tip: Run 'docker-compose up -d' in this directory."
fi

if [ "$(docker ps -q -f name=postgres)" ]; then
    echo "[PASS] Postgres container is running."
else
    echo "[FAIL] Postgres container is NOT running."
fi

# 3. Check Nakama API Response
echo "Checking Nakama API availability..."
HTTP_CODE=$(curl --write-out "%{http_code}\n" --silent --output /dev/null "http://localhost:7350/")

if [ "$HTTP_CODE" -eq 200 ]; then
    echo "[PASS] Nakama API is accessible at http://localhost:7350."
    echo "=== System Ready ==="
else
    echo "[FAIL] Nakama API returned HTTP $HTTP_CODE (Expected 200)."
    echo "Tip: The server might still be starting up. Wait a few seconds and try again."
fi
