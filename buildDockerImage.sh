#!/bin/bash

# Docker commands

version="0.0.1-beta"
name="nuke.prcommitsvalidations"
repo="cangulomascarell/$name"
id="$repo:$version"

echo "version:$version"
echo "name:$name"
echo "repo:$repo"
echo "id:$id"

echo "creating docker image"
docker image build -t $id --no-cache .
