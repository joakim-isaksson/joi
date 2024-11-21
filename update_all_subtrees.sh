#!/bin/bash

# Base path where all module folders are located
BASE_PATH="JoiUnity/Assets/Joi"

# Branch name prefix (you can customize this)
BRANCH_PREFIX="joi"

# Script to update individual subtree branches
SUBTREE_SCRIPT="./update_subtree_branch.sh"

# Check if the update_subtree_branch script exists and is executable
if [ ! -x "$SUBTREE_SCRIPT" ]; then
    echo "Error: $SUBTREE_SCRIPT not found or not executable."
    exit 1
fi

echo "Updating all module subtrees in $BASE_PATH..."

# Loop through all directories in the base path
for folder in "$BASE_PATH"/*; do
    if [ -d "$folder" ]; then  # Only process directories
        # Extract the folder name (module name)
        folder_name=$(basename "$folder")
        
        # Convert folder name to lowercase using `tr`
        branch_name="${BRANCH_PREFIX}-$(echo "$folder_name" | tr '[:upper:]' '[:lower:]')"
        
        echo "Updating $folder_name..."
        
        # Call the update script with the folder path and branch name
        $SUBTREE_SCRIPT "$folder" "$branch_name"
        
        if [ $? -ne 0 ]; then
            echo "Error: Failed to update $folder_name."
            continue
        fi
    else
        echo "Skipping non-directory item: $folder"
    fi
done

echo "...done"