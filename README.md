# Student Workflow: Fork, Clone, Work from Tags, and Stay in Sync with Class Demo Repo

**Course:** CS 276 — Unity Workshop 3 (2D Car Game)  
**Class Demo Repo (original / upstream):** https://github.com/LucasCordova/UnityClassDemo2D

This guide shows how to:

1. **Fork** the class demo repository.
2. **Clone your fork** locally.
3. **Add the upstream remote** to stay in sync.
4. **Fetch and switch to a tag** (e.g., `workshop3-part2-2025-09-10`).
5. **Create a working branch from a tag**, commit, and push.
6. **Update your fork** with the class demo’s latest code on `main` and **pull the newest tags** after each lecture.

---

## 1) Fork the Class Repository from GitHub

1. Visit the repo: [https://github.com/LucasCordova/UnityClassDemo2D](https://github.com/LucasCordova/UnityClassDemo2D)
2. Click **Fork** (top-right) and create the fork under **your** GitHub account.

---

## 2) Clone *Your Fork* Locally

> Replace `<your-username>` with your GitHub username.

```bash
git clone https://github.com/<your-username>/UnityClassDemo2D.git
cd UnityClassDemo2D
```

---

## 3) Add the Class Demo Repo as `upstream` (One-Time Setup)

This lets you pull the latest code/tags from the class demo repo after each lecture.

```bash
git remote add upstream https://github.com/LucasCordova/UnityClassDemo2D.git

# Verify
git remote -v

# You should see:
# origin   https://github.com/<your-username>/UnityClassDemo2D.git (fetch)
# origin   https://github.com/<your-username>/UnityClassDemo2D.git (push)
# upstream https://github.com/LucasCordova/UnityClassDemo2D.git (fetch)
# upstream https://github.com/LucasCordova/UnityClassDemo2D.git (push)
```

---

## 4) Get Tags and Switch to a Specific Class Snapshot

The **`main`** branch has the latest code, but it may be mid-lecture and not stable. Instead, I will publish tags after each lecture (snapshots you can branch from). Example tags:

- `workshop3-part1-2025-09-08`
- `workshop3-part2-2025-09-10`
- `workshop3-part3-2025-09-15`

**Fetch all tags from upstream, then list them:**

```bash
git fetch upstream --tags
git tag --list
```

**Switch to a specific tag (detached HEAD):**

```bash
git checkout workshop3-part2-2025-09-10
```

> You’re now looking at the exact code from that lecture snapshot.

---

## 5) Create a Working Branch *from a Tag*

You shouldn’t commit directly on a tag (it’s read-only). Instead, create a branch that **starts at the tag**.

```bash
# Example: branch name "my-work-part2"
git switch -c my-work-part2 workshop3-part2-2025-09-10

# Make changes (code, scenes, scripts), then stage and commit:
git add -A
git commit -m "My changes based on workshop3-part2 snapshot"

# Push your branch to *your fork* (origin):
git push -u origin my-work-part2
```

> Replace `my-work-part2` with your preferred branch name. You’ll share this branch link for submissions if required.

---

## 6) Open and Run in Unity

1. Open **Unity Hub** → **Add** → select this cloned repo folder.  
2. Open with **Unity 6** (or the version in `ProjectSettings/ProjectVersion.txt`).  
3. Press **Play** to run the scene.

---

## 7) Stay Up to Date After Each Lecture

When I push new code to **`main`** and publish new **tags**, update your local repo and your fork.

**Step A — Fetch from `upstream` (instructor)**

```bash
# Get the latest commits and tags from the instructor
git fetch upstream --tags
```

**Step B — Update your `main` to match the class demo repo `main`**

```bash
git switch main
git merge upstream/main        # or: git rebase upstream/main
git push origin main
```

**Step C — Update your working branch with the new `main`**

```bash
git switch my-work-part2
git merge main                 # or: git rebase main
# Resolve any conflicts if they happen, then:
git push
```

**Step D — (Optional) Start a new branch from a newer tag**
If I publish a new tag, you can start fresh from that snapshot:

```bash
git switch -c my-work-part3 workshop3-part3-YYYY-MM-DD
git push -u origin my-work-part3
```

---

## 8) Common Issues & Fixes

- **“I can’t push my branch”** → Make sure you cloned **your fork** (your GitHub username in the URL). You can only push to your fork unless you’re a collaborator on the class demo repo.
- **“I don’t see new tags”** → Run `git fetch upstream --tags`.
- **“Unity assets missing/large files?”** → See Git LFS note below.
- **Conflicts when merging/rebasing** → Open the files shown by Git, resolve conflicts, then:

  ```bash
  git add -A
  git commit      # or: git rebase --continue
  git push
  ```

---

## 9) Verify Your Remotes Anytime

You should have two remotes: `origin` (your fork) and `upstream` (the class demo repo).

```bash
git remote -v
# origin   -> your fork (push here)
# upstream -> class demo repo (read-only for you)
```

---

### You’re set

Best practices summary:

- Fork once.  
- Work in branches created **from tags**.  
- Periodically: `git fetch upstream --tags`, update your `main` from `upstream/main`, then merge/rebase into your working branch.
