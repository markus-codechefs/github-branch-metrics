# Github branch lifetime measurmenet tool

[![GitHub release](https://img.shields.io/github/release/markus-codechefs/github-branch-lifetime?include_prereleases=&sort=semver&color=blue)](https://github.com/markus-codechefs/github-branch-lifetime/releases/)
[![License](https://img.shields.io/badge/License-MIT-blue)](#license)
[![issues - github-branch-lifetime](https://img.shields.io/github/issues/markus-codechefs/github-branch-lifetime)](https://github.com/markus-codechefs/github-branch-lifetime/issues)

## CI
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=markus-codechefs_github-branch-lifetime&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=markus-codechefs_github-branch-lifetime)
![example workflow](https://github.com/markus-codechefs/github-branch-lifetime/actions/workflows/build.yml/badge.svg)

## Short summary
A blazor app which calls the github api to query branch creation and merge date. And evaluates the lifetime in days of branches in each repository specified.  

![image](https://user-images.githubusercontent.com/62404942/159014939-7ad85291-7e39-4b69-b4af-217a15f1372e.png)

## How is this achieved?
There is no branch creation date in github as a branch is merely a pointer to a commit. So the most sane thing I came up with was the oldest commit on a branch.

#### Get all Pull Requests
https://api.github.com/repos/markus-codechefs/github-branch-lifetime/pulls


- Uses the MergedAt date as the end date of the measurement.

#### Get all commits per Pull Request
https://api.github.com/repos/{org}/{repo}/pulls/{PR.Number}/commits

- Uses CreatedAt of the oldest commit on a branch for the start of the measurement.



## License

Released under [MIT](/LICENSE) by [@markus-codechefs](https://github.com/markus-codechefs).
