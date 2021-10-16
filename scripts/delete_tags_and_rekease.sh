#!/bin/bash

tags=(0.0.1 0.0.2 0.0.3)
for tag in "${tags[@]}"; do
    git tag -d $tag
    git push --delete origin $tag
    gh release delete $tag -y
done
