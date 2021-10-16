#!/bin/bash

# Docker commands

version="0.0.2-beta"
name="nuke.prcommitsvalidations"
repo="cangulomascarell/$name"
id="$repo:$version"

echo "version:$version"
echo "name:$name"
echo "repo:$repo"
echo "id:$id"

echo "pusing docker image"
docker push $id
