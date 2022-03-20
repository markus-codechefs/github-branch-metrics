# Github branch lifetime measurmenet tool

[![GitHub release](https://img.shields.io/github/release/markus-codechefs/github-branch-lifetime?include_prereleases=&sort=semver&color=blue)](https://github.com/markus-codechefs/github-branch-lifetime/releases/)
[![License](https://img.shields.io/badge/License-MIT-blue)](#license)
[![issues - github-branch-lifetime](https://img.shields.io/github/issues/markus-codechefs/github-branch-lifetime)](https://github.com/markus-codechefs/github-branch-lifetime/issues)

## CI
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=markus-codechefs_github-branch-lifetime&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=markus-codechefs_github-branch-lifetime)
![example workflow](https://github.com/markus-codechefs/github-branch-lifetime/actions/workflows/build.yml/badge.svg)
![example workflow](https://github.com/markus-codechefs/github-branch-lifetime/actions/workflows/codeql-analysis.yml/badge.svg)

## Short summary
A base package will offer the statistic to display for other apps. A blazor app and a console app are offered as examples. They will call the package which then calls the github api to query the branch statistics.  

## Why is branch lifespan important?
Data from the book ["Accelerate"](https://www.amazon.com/Accelerate-Software-Performing-Technology-Organizations/dp/1942788339) and ["State of DevOps Report"](https://cloud.google.com/blog/products/devops-sre/announcing-dora-2021-accelerate-state-of-devops-report) have shown that consistently merging code to trunk (repository main branch) multiple times a day delivers high performance in technology organizations. 

https://techbeacon.com/app-dev-testing/how-trunk-based-delivery-key-faster-more-reliable-software

At the time of writing I have not found any library which offers to measure the amount of time spent developing on non-trunk branches. Measuring the lifespan of your organisation's feature branches will give insight into:
  - the state of software delivery in general
  - the average batch size being delivered 
  - the average lead time to deliver a feature 

![image](https://user-images.githubusercontent.com/62404942/159183736-49460ecd-e855-4049-9f82-2f55bb2eb7be.png)

## Some context
There is no branch creation date in github as a branch is merely a pointer to a commit. So the most sane thing I came up with was the oldest commit on a branch.

#### Get all Pull Requests
https://api.github.com/repos/markus-codechefs/github-branch-lifetime/pulls


- Uses the MergedAt date as the end date of the measurement.

#### Get all commits per Pull Request
https://api.github.com/repos/{org}/{repo}/pulls/{PR.Number}/commits

- Uses CreatedAt of the oldest commit on a branch for the start of the measurement.



## License

Released under [MIT](/LICENSE) by [@markus-codechefs](https://github.com/markus-codechefs).
