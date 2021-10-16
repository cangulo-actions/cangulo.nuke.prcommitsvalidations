#!/usr/bin/env bash

# $1 is the version provided
REGEX_VALIDATE_VERSION="^(latest)$|(^[0-9]+\.[0-9]+\.[0-9]+$)"

version=$1

echo "version $version"

echo "::group::listing docker files"
ls
echo "::endgroup::"

cd $GITHUB_WORKSPACE

echo "::group::listing all files after cd $GITHUB_WORKSPACE"
ls
echo "::endgroup::"

# echo "::group::executing pr validation"
cangulo.nuke.prcommitsvalidations ValidatePRCommits --root .

# echo "::endgroup::"
