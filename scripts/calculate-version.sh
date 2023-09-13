#!/bin/bash

echo "Script is running..."

latest_tag=$(git describe --tags --match "v*" --abbrev=0)

tag_version="${latest_tag#v}"

echo "Tag version: $tag_version"

sed -i "s/<version>.*<\/version>/<version>$tag_version<\/version>/" WeatherCapybara.nuspec

echo "Set version to: $tag_version"
