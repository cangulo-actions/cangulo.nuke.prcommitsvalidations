# Example 

```yml
- name: Validating PR commits
  uses: cangulo-actions/cangulo.nuke.prcommitsvalidations@v0.0.1
  with:
    validationSettingsPath: ./cicd/prCommitValidationSettings.json
```

Please provide the next parameters:
* **validationSettingsPath** -> path to the json file with the conventional commits accepted. Next is an example:

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
# Remarks

* Only use this GH action with a PR event. This is because solution depends on the PR number provided in the `${{ github.event.number }}` parameter. 

# Solution repo
The source code is in the next repo:

https://github.com/cangulo/cangulo.nuke.prcommitsvalidations