# Example 

```yml
name: Validating Conventional Commits

on:
  workflow_dispatch:
  pull_request:
    types: [opened, synchronize]


jobs:
  validate-conventional-commits:
    name: Validating Conventional Commits
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
      - name: Validating PR commits
        uses: cangulo-actions/cangulo.nuke.prcommitsvalidations@v0.0.1
        with:
          validationSettingsPath: ./cicd/prCommitValidationSettings.json
```

## Requirement

Define the conventional commits in a json file as next:

```json
{
    "conventionalCommitTypes": [
        "fix",
        "patch",
        "feat",
        "major"
    ]
}
```

Then, provide it in the parameter validationSettingsPath.

# Remarks

* Only use this GH action with a PR event. This is because solution depends on the PR number provided in the `${{ github.event.number }}` parameter. 

# Solution repo
The source code is in the next repo:

https://github.com/cangulo/cangulo.nuke.prcommitsvalidations