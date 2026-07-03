#!/bin/bash
BUILD_DIR="Builds/WebGL"
TEMP_DIR="/tmp/webgl-deploy"

# Build in Unity first, then run this script

# Copy build to temp
rm -rf $TEMP_DIR
mkdir -p $TEMP_DIR
cp -r $BUILD_DIR/* $TEMP_DIR/

# Switch to gh-pages
git checkout gh-pages

# Clear old files (keep .git)
find . -maxdepth 1 -not -name '.git' -not -name '.' -not -name '..' -exec rm -rf {} +

# Copy new build
cp -r $TEMP_DIR/* .

# Commit and push
git add .
git commit -m "Update WebGL build"
git push origin gh-pages

# Switch back
git checkout main