# Git notes
## Task 15 — Basic git
### Commands
- git checkout -b feature/git-basics
- git merge feature/git-basics
- (разрешал конфликт вручную)
### Output (git log --graph --oneline --all)
*   0d76446 (HEAD -> level-1) merge: task 15 - resolve readme conflict
|\
| * 8c51b19 (feature/git-basics) fix: task 15 - conflicting readme line in feature
* | 268e08d fix: task 15 - conflicting readme line in level-1
|/
| *   01b1b2a (refs/stash) On feature/git-basics: Извлечение level-1
|/|\
| | * c676b5f untracked files on feature/git-basics: 0bf11c2 task 15
| * feb3d46 index on feature/git-basics: 0bf11c2 task 15
|/
* 0bf11c2 (origin/level-1) task 15
* 3ae6e34 task 14
* d096047 task 13
* 1421915 task 12
* 4c4a7bf task 11
* 69c1d11 task 10
* 7178a19 task 9
* e40b2e5 task08
* 90f3ad6 task07
* a480ac5 task 06
* 41da71c task 05
* a06e80c task 04
* f3eedf7 task3
* c30a27e task2
| * 707028c (origin/master, origin/HEAD) Update README.md
| *   e1a3f4f Merge pull request #1 from neketon/level1
:
*   0d76446 (HEAD -> level-1) merge: task 15 - resolve readme conflict
|\
| * 8c51b19 (feature/git-basics) fix: task 15 - conflicting readme line in feature
* | 268e08d fix: task 15 - conflicting readme line in level-1
|/
| *   01b1b2a (refs/stash) On feature/git-basics: Извлечение level-1
|/|\
| | * c676b5f untracked files on feature/git-basics: 0bf11c2 task 15
| * feb3d46 index on feature/git-basics: 0bf11c2 task 15
|/
* 0bf11c2 (origin/level-1) task 15
* 3ae6e34 task 14
* d096047 task 13
* 1421915 task 12
* 4c4a7bf task 11
* 69c1d11 task 10
* 7178a19 task 9
* e40b2e5 task08
* 90f3ad6 task07
* a480ac5 task 06
* 41da71c task 05
* a06e80c task 04
* f3eedf7 task3
* c30a27e task2
| * 707028c (origin/master, origin/HEAD) Update README.md
| *   e1a3f4f Merge pull request #1 from neketon/level1
| |\
| |/
|/|
* | d980fe5 (origin/level1) Task1
|/
* 71f048e (master) Добавьте файлы проекта.
* e9b3ad3 Добавить .gitattributes.
### What I learned
Научился создавать ветки, делать слияние (merge) и вручную разрешать конфликты в файлах.