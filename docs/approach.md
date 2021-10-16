# Definitions

* solution repo: repo where the source code is stored. In this case: `cangulo/cangulo.nuke.prcommitsvalidations`, [link](https://github.com/cangulo/cangulo.nuke.prcommitsvalidations).
* GH action repo: repo where the GitHub action is stored, here it is defined how to provide the solution in any pipeline. [Link](https://github.com/cangulo-actions/cangulo.nuke.prcommitsvalidations)

# Approach options for this repo

1. Download the dotnet executable files
2. Have the dotnet executable files in the repository

# Questions

* Should this repo and the solution repo have the same version? If a new version is released in the solution, should this repo be updated?

# First Approach: Download the dotnet executable files

## Description

* Pass the version to be download as a parameter in the action.yml

## Advantages

* Only one version of this GH action is required because this repo will only be a proxy for the execution of the solution
* Easier implementation because this repo is independent of the solution. If new releases of the solution don't require input parameters this repo doesn't have to be updated
  
## Disadvantage

* Performance is worse, probably download the artifact and unzip requires more time than having it in this repo
* If a breaking changes is introduced, lets say that the solution requires a new input parameter from the version X (e.g. 0.0.42) we should release a new version of this repo which will only accept the version X (e.g. 0.0.42) or later.

# Second Approach: Have the dotnet executable files in the repository

## Description

* Every time the solution release a new version, a new PR is created in this repo to update the executable files. Approach, 

## Advantages

* Better performance
  
## Disadvantage

* Highly dependency between two reports

# Decision

Taking the performance as the main goal, I have decided to go with the second approach. 

## Answers

* Should this repo and the solution repo have the same version? If a new version is released in the solution, should this repo be updated?
  * It is not required but as this repo is a GitHub action of the other, I think it is easier to make both have the same version.

# Implementation

1. When a new version is release in the solution, a GH action with the next steps will be triggered
   1. Build and package the dotnet solution
   2. Checkout the GH action repo
   3. Create a new branch named `release/[VERSION]`
   4. Add the packaged solution to the app folder
   5. Commit it
      1. Initially, only use the `fix` conventional commit
      2. Future improvement, use the same release type as the one used in the solution repo
   6. Create PR using


## docs

https://docs.github.com/en/actions/advanced-guides/using-github-cli-in-workflows