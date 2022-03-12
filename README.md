# Github branch lifetime measurmenet tool
A client which calls the github api to query branch creation and merge date.

![image](https://user-images.githubusercontent.com/62404942/157924438-46408e11-dbe0-4323-a686-6bd1fd95c66f.png)

## Statsistics Logic
There is no branch creation date in github as a branch is merely a pointer to a commit. So the most sane thing I came up with was the oldest commit on a branch.

#### Get all Pull Requests
https://api.github.com/repos/markus-codechefs/github-branch-lifetime/pulls

- Use the MergedAt date as the end date of the measurement.
- Enable the client to set a date how far back Pull Requests should be considered.

#### Get all commits per Pull Request
https://api.github.com/repos/markus-codechefs/github-branch-lifetime/pulls/5/commits

- Use the CreatedAt Date for the start of the statistic. 
- Loop through each PR's commits and pick the oldest. 