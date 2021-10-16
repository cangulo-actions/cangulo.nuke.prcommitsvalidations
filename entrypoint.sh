#!/usr/bin/env bash

# $1 is the version provided
REGEX_VALIDATE_VERSION="^(latest)$|(^[0-9]+\.[0-9]+\.[0-9]+$)"

version=$1

echo "version $version"

echo "::group::pwd"
pwd
echo "::endgroup::"

echo "::group::listing docker files"
ls
echo "::endgroup::"

echo "::group::listing docker files .."
ls ..
echo "::endgroup::"
