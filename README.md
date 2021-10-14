# Example 
```yml
- name: Validating PR commits
  uses: cangulo-actions/cangulo.nuke.prcommitsvalidations@0.0.1
  with:
    githubToken: ${{ secrets.GITHUB_TOKEN }}
    validationSettingsPath: ./cicd/prCommitValidationSettings.json
```

Please provide the next parameters:
* **githubToken** -> needed for querying the GH API in order to list the commits
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