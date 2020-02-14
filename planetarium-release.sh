#!/bin/sh
if [ "$1" = "" ]; then
  echo "usage: $0 VERSION" > /dev/stderr
  exit 1
fi

version="$1"
dotnet clean RocksDbSharp.sln
rm -rf RocksDbSharp/bin/
dotnet restore RocksDbSharp.sln
dotnet build RocksDbSharp.sln \
  /p:Configuration=Release \
  /p:PackageVersion="$version-planetarium" \
  /p:Version="$version" \
  /verbosity:minimal
dotnet pack RocksDbSharp/RocksDbSharp.csproj \
  -c Release \
  --no-build \
  /p:PackageVersion="$version-planetarium" \
  /p:Version="$version"
