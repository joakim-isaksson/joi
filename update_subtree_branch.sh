#!/bin/bash

# Check if the correct number of arguments is provided
if [ "$#" -ne 2 ]; then
    echo "Usage: $0 <path> <branchName>"
    exit 1
fi

# Assign arguments to variables
PATH_PREFIX=$1
BRANCH_NAME=$2

# Check if the branch exists locally
if git show-ref --quiet refs/heads/"$BRANCH_NAME"; then
    echo "Deleting existing subtree branch: $BRANCH_NAME"
    git branch -D "$BRANCH_NAME"
fi

# Recreate the subtree branch with the latest changes
echo "Creating new subtree branch: $BRANCH_NAME from path: $PATH_PREFIX"
git subtree split --prefix="$PATH_PREFIX" -b "$BRANCH_NAME"

if [ $? -ne 0 ]; then
    echo "Error: Failed to create subtree branch."
    exit 1
fi

# Push the recreated branch to origin
echo "Pushing branch $BRANCH_NAME to origin..."
git push origin "$BRANCH_NAME" --force

if [ $? -ne 0 ]; then
    echo "Error: Failed to push branch to origin."
    exit 1
fi

echo "Subtree branch $BRANCH_NAME has been updated successfully."